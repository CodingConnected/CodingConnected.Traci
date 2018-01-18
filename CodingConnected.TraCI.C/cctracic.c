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

    // Free!
    free(command.Contents);
    FreeResults(results);
}

void TraCISetOrder(int order)
{
    TraCICommand command;
    command.Identifier = 0x03;
    command.Contents = (char *)malloc(sizeof(char) * 4);
    command.ContentsLength = 4;
    
    int n = order;
    *(command.Contents + 3) = n & 0xFF;
    *(command.Contents + 2) = (n >> 8) & 0xFF;
    *(command.Contents + 1) = (n >> 16) & 0xFF;
    *(command.Contents) = (n >> 24) & 0xFF;

    TraCIResults results = SendTraCIMessage(command);
    // TODO: handle response

    // Free!
    free(command.Contents);
    FreeResults(results);
}

double TraCIGetLaneAreaLastStepOccupancy(const char * id)
{
    TraCICommand command;
    command.Identifier = CMD_GET_LANEAREA_VARIABLE;
    int n = strlen(id);
    command.ContentsLength = 5 + n;
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
    *command.Contents = LAST_STEP_OCCUPANCY;
    *(command.Contents + 1) = (n >> 24) & 0xFF;
    *(command.Contents + 2) = (n >> 16) & 0xFF;
    *(command.Contents + 3) = (n >> 8) & 0xFF;
    *(command.Contents + 4) = n & 0xFF;
    for (int i = 5; i < command.ContentsLength; i++)
    {
        *(command.Contents + i) = *(id + (i - 5));
    }

    TraCIResults results = SendTraCIMessage(command);

    if (results.Count > 0)
    {
        for (int i = 0; i < results.Count; i++)
        {
            TraCIResult result = *(results.Results + i);
            if (result.Identifier == RESPONSE_GET_LANEAREA_VARIABLE &&
                *result.Contents == LAST_STEP_OCCUPANCY)
            {
                int32_t idLength = 0;
                for (int j = 0; j < 4; j++) {
                    idLength <<= 4;
                    idLength |= *(result.Contents + j + 1);
                }
                //var ids = BitConverter.ToString(r.Response, 5, idl);
                unsigned char type = *(result.Contents + 5 + idLength);
                double perOcc = 0;
                unsigned char dbl[8];
                dbl[7] = *(result.Contents + 6 + idLength);
                dbl[6] = *(result.Contents + 7 + idLength);
                dbl[5] = *(result.Contents + 8 + idLength);
                dbl[4] = *(result.Contents + 9 + idLength);
                dbl[3] = *(result.Contents + 10 + idLength);
                dbl[2] = *(result.Contents + 11 + idLength);
                dbl[1] = *(result.Contents + 12 + idLength);
                dbl[0] = *(result.Contents + 13 + idLength);
                memcpy(&perOcc, dbl, 8);
                return perOcc;
            }
        }
    }
    return -1;
}

void TraCISetTrafficLightState(const char * trafficLightId, const char * state)
{
    TraCICommand command;
    command.Identifier = CMD_SET_TL_VARIABLE;
    int idLen = strlen(trafficLightId);
    int stLen = strlen(state);
    command.ContentsLength = 10 + idLen + stLen;
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
    *command.Contents = TL_RED_YELLOW_GREEN_STATE;
    *(command.Contents + 1) = (idLen >> 24) & 0xFF;
    *(command.Contents + 2) = (idLen >> 16) & 0xFF;
    *(command.Contents + 3) = (idLen >> 8) & 0xFF;
    *(command.Contents + 4) = idLen & 0xFF;
    int i = 5;
    for (; i < idLen + 5; i++)
    {
        *(command.Contents + i) = *(trafficLightId + (i - 5));
    }
    *(command.Contents + i) = TYPE_STRING;
    *(command.Contents + i + 1) = (stLen >> 24) & 0xFF;
    *(command.Contents + i + 2) = (stLen >> 16) & 0xFF;
    *(command.Contents + i + 3) = (stLen >> 8) & 0xFF;
    *(command.Contents + i + 4) = stLen & 0xFF;
    int p = idLen + stLen + 10;
    int k = 0;
    for (i = i + 5; i < p; i++)
    {
        *(command.Contents + i) = *(state + k);
        k++;
    }

    TraCIResults results = SendTraCIMessage(command);
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
        for (int i = 0; i < 4; i++) {
            messageLength <<= 4;
            messageLength |= IncomingBytesBuffer[i];
        }

        TraCIResults results;

        TraCIResult temp[32];
        int resultIndex = 0;
        for (int curIndex = 4; curIndex < messageLength; )
        {
            int curMsgIndex = 0;
            int len = IncomingBytesBuffer[curIndex + curMsgIndex++];
            if (len == 0)
            {
                if (curMsgIndex + 3 < len)
                {
                    int32_t _curMsgLength = 0;
                    for (int i = 0; i < 4; i++) {
                        _curMsgLength <<= 4;
                        _curMsgLength |= IncomingBytesBuffer[curIndex + curMsgIndex + i];
                    }
                    temp[resultIndex].ContentsLength = _curMsgLength - 6;
                    curMsgIndex += 4;
                }
                else
                {
                    break;
                }
            }
            else
            {
                temp[resultIndex].ContentsLength = len - 2; // bytes lenght will be: msg - length - id
            }
            if (temp[resultIndex].ContentsLength > 0)
                temp[resultIndex].Contents = (unsigned char *)malloc(sizeof(unsigned char) * temp[resultIndex].ContentsLength);
            temp[resultIndex].Identifier = (unsigned char)IncomingBytesBuffer[curIndex + curMsgIndex++];
            int k = 0;
            while (curMsgIndex < len)
            {
                *(temp[resultIndex].Contents + k) = IncomingBytesBuffer[curIndex + curMsgIndex++];
                k++;
            }
            curIndex += curMsgIndex;
            resultIndex++;
        }
        TraCIResult * ttemp = (TraCIResult *)malloc(sizeof(TraCIResult) * (resultIndex + 1));
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
        if (result.ContentsLength > 0)
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