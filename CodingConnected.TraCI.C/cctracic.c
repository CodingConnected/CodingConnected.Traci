#include "cctracic.h"
#include <stdint.h>

int TraCIConnect(char * hostname, char * port)
{
    Hostname = hostname;
    Port = port;

    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0) {
        printf("WSAStartup failed with error: %d\n", iResult);
        return 1;
    }

    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;

    // Resolve the server address and port
    iResult = getaddrinfo(hostname, Port, &hints, &result);
    if (iResult != 0) {
        printf("getaddrinfo failed with error: %d\n", iResult);
        WSACleanup();
        return 1;
    }

    // Attempt to connect to an address until one succeeds
    for (ptr = result; ptr != NULL; ptr = ptr->ai_next) {

        // Create a SOCKET for connecting to server
        ConnectSocket = socket(ptr->ai_family, ptr->ai_socktype,
            ptr->ai_protocol);
        if (ConnectSocket == INVALID_SOCKET) {
            printf("socket failed with error: %ld\n", WSAGetLastError());
            WSACleanup();
            return 1;
        }

        // Connect to server.
        iResult = connect(ConnectSocket, ptr->ai_addr, (int)ptr->ai_addrlen);
        if (iResult == SOCKET_ERROR) {
            closesocket(ConnectSocket);
            ConnectSocket = INVALID_SOCKET;
            continue;
        }
        break;
    }

    freeaddrinfo(result);

    if (ConnectSocket == INVALID_SOCKET) {
        printf("Unable to connect to server!\n");
        WSACleanup();
        return 1;
    }

    Connected = 1;

    atexit(TraCICloseConnection);

    return 0;
}

void TraCICloseConnection()
{
    if(!Connected)
    {
        return;
    }
    closesocket(ConnectSocket);
    ConnectSocket = INVALID_SOCKET;
    WSACleanup();
}

void TraCIControlSimStep()
{
    TraCICommand command;
    command.Identifier = CMD_SIMSTEP;
    command.Contents = (char *)malloc(sizeof(char) * 4);
    command.ContentsLength = 4;
    for (int i = 0; i < 4; i++)
    {
        *(command.Contents + i) = 0;
    }
   
    TraCIResults results = SendTraCIMessage(command);
    // TODO: handle response
    FreeResults(results);
}

TraCIResults SendTraCIMessage(TraCICommand command)
{
    if (!Connected)
    {
        TraCIResults results = { -1, NULL };
        return results;
    }

    int messageLength = GetMessageBytes(command, OutgoingBytesBuffer);
    
    iResult = send(ConnectSocket, OutgoingBytesBuffer, messageLength, 0);
    if (iResult == SOCKET_ERROR) {
        printf("send failed with error: %d\n", WSAGetLastError());
        TraCIResults results = { -2, NULL };
        return results;
    }

    iResult = recv(ConnectSocket, IncomingBytesBuffer, MAXTCPBUFFER, 0);
    if (iResult > 0)
    {
        messageLength = 0;
        for (int i = 3; i >= 0; i--) {
            messageLength <<= 4;
            messageLength |= IncomingBytesBuffer[i];
        }

        TraCIResults results;

        TraCIResult temp[32];
        int resultIndex = 0;
        for (int curIndex = 4; curIndex < messageLength; curIndex++)
        {
            TraCIResult result;
            int curMsgIndex = 0;
            int len = IncomingBytesBuffer[curIndex + curMsgIndex++];
            if (len == 0)
            {
                if (curMsgIndex + 3 < len)
                {
                    int32_t _curMsgLength = 0;
                    for (int i = 3; i >= 0; i--) {
                        messageLength <<= 4;
                        messageLength |= IncomingBytesBuffer[curIndex + curMsgIndex + i];
                    }
                    result.ContentsLength = _curMsgLength - 6;
                    curMsgIndex += 4;
                }
                else
                {
                    break;
                }
            }
            else
            {
                result.ContentsLength = len - 2; // bytes lenght will be: msg - length - id
            }
            result.Contents = (char *)malloc(sizeof(char) * result.ContentsLength);
            result.Identifier = IncomingBytesBuffer[curIndex + curMsgIndex++];
            while (curMsgIndex < len)
            {
                *(result.Contents + curMsgIndex) = IncomingBytesBuffer[curIndex + curMsgIndex++];
            }
            curIndex += curMsgIndex;
            temp[resultIndex++] = result;

        }
        TraCIResult * ttemp = (TraCIResult *)malloc(sizeof(TraCIResult) * resultIndex);
        for (int i = 0; i < resultIndex; i++)
        {
            *(ttemp + i) = temp[i];
        }
        results.Count = resultIndex;
        results.Results = ttemp;
        return results;
    }
    printf("receive failed with error: %d\n", WSAGetLastError());
    TraCIResults results = { -2, NULL };
    return results;
}

static void FreeResults(TraCIResults results)
{
    for (int i = 0; i < results.Count; i++)
    {
        TraCIResult result = *(results.Results + i);
        free(result.Contents);
    }
    free(results.Results);
}

static int GetMessageBytes(TraCICommand command, char * bytesBuffer)
{
    TraCICommand * commands = (TraCICommand *)malloc(sizeof(TraCICommand));
    *commands = command;
    int bytesNum = GetMessagesBytes(commands, 1, bytesBuffer);
    free(commands);
    return bytesNum;
}

static int GetMessagesBytes(TraCICommand * commands, int commandsCount, char * bytesBuffer)
{
    int curIndex = 4;
    for (int curCommandIndex = 0; curCommandIndex < commandsCount; ++curCommandIndex)
    {
        TraCICommand curCommand = *(commands + curCommandIndex);
        if (curCommand.ContentsLength == 0)
        {
            *(bytesBuffer + curIndex) = 2; // no contents: only length self and id => 2
            ++curIndex;
        }
        else if (curCommand.ContentsLength + 2 <= 255)
        {
            *(bytesBuffer + curIndex) = curCommand.ContentsLength + 2;
            ++curIndex;
        }
        else
        {
            *(bytesBuffer + curIndex) = 0;
            ++curIndex;
            int n = curCommand.ContentsLength + 6;
            *(bytesBuffer + curIndex) = (n >> 24) & 0xFF;
            ++curIndex;
            *(bytesBuffer + curIndex) = (n >> 16) & 0xFF;
            ++curIndex;
            *(bytesBuffer + curIndex) = (n >> 8) & 0xFF;
            ++curIndex;
            *(bytesBuffer + curIndex) = n & 0xFF;
            ++curIndex;
        }
        *(bytesBuffer + curIndex) = curCommand.Identifier;
        ++curIndex;
        if (curCommand.ContentsLength != 0)
        {
            for (int j = 0; j < curCommand.ContentsLength; ++j)
            {
                *(bytesBuffer + curIndex) = *(curCommand.Contents + j);
                ++curIndex;
            }
        }
        int n = curCommand.ContentsLength + 6;
        *(bytesBuffer + 3) = n & 0xFF;
        *(bytesBuffer + 2) = (n >> 8) & 0xFF;
        *(bytesBuffer + 1) = (n >> 16) & 0xFF;
        *(bytesBuffer) = (n >> 24) & 0xFF;
    }

    return curIndex;
}