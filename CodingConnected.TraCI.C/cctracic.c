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

void TraCICloseConnection(void)
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
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * 8);
    command.ContentsLength = 8;
    for (int i = 0; i < 8; i++)
    {
        *(command.Contents + i) = 0;
    }

    const TraCIResults results = SendTraCIMessage(command);

    FreeCommand(command);
    FreeResults(results);
}

void TraCISetOrder(int order)
{
    TraCICommand command;
    command.Identifier = 0x03;
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * 4);
    command.ContentsLength = 4;

    const int n = order;
    *(command.Contents + 3) = n & 0xFF;
    *(command.Contents + 2) = (n >> 8) & 0xFF;
    *(command.Contents + 1) = (n >> 16) & 0xFF;
    *(command.Contents) = (n >> 24) & 0xFF;

    const TraCIResults results = SendTraCIMessage(command);

    FreeCommand(command);
    FreeResults(results);
}

int TraCIGetInductionLoopLastStepVehicleNumber(const char * id, const char * vehTypeId)
{
	TraCICommand command;
	command.Identifier = CMD_GET_INDUCTIONLOOP_VARIABLE;
	const unsigned int n = strlen(id);
	command.ContentsLength = 5 + n;
	command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
	*command.Contents = LAST_STEP_VEHICLE_NUMBER;
	*(command.Contents + 1) = (n >> 24) & 0xFF;
	*(command.Contents + 2) = (n >> 16) & 0xFF;
	*(command.Contents + 3) = (n >> 8) & 0xFF;
	*(command.Contents + 4) = n & 0xFF;
	for (int i = 5; i < command.ContentsLength; i++)
	{
		*(command.Contents + i) = *(id + (i - 5));
	}

	const TraCIResults results = SendTraCIMessage(command);

	if (results.Count > 0)
	{
		for (int i = 0; i < results.Count; ++i)
		{
			const TraCIResult result = *(results.Results + i);
			if (result.Identifier == RESPONSE_GET_INDUCTIONLOOP_VARIABLE &&
				*result.Contents == LAST_STEP_VEHICLE_NUMBER)
			{
				int32_t id_length = 0;
				for (int j = 0; j < 4; ++j) {
					id_length <<= 4;
					id_length |= *(result.Contents + j + 1);
				}
				unsigned char type = *(result.Contents + 5 + id_length);
				int per_num_veh = 0;
				unsigned char integer[4];
				integer[3] = *(result.Contents + 6 + id_length);
				integer[2] = *(result.Contents + 7 + id_length);
				integer[1] = *(result.Contents + 8 + id_length);
				integer[0] = *(result.Contents + 9 + id_length);
				memcpy(&per_num_veh, integer, 4);

				FreeCommand(command);
				FreeResults(results);
				
				return per_num_veh;
			}
		}
	}

	FreeCommand(command);
	FreeResults(results);
	
	return 0;
}

/*
int TraCIGetInductionLoopVehicleTypeLastStepOccupance(const char * id, const char * vehTypeId)
{
	TraCICommand command;
	command.Identifier = CMD_GET_INDUCTIONLOOP_VARIABLE;
	int n = strlen(id);
	command.ContentsLength = 5 + n;
	command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
	*command.Contents = LAST_STEP_VEHICLE_DATA;
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
		for (int i = 0; i < results.Count; ++i)
		{
			TraCIResult result = *(results.Results + i);
			if (result.Identifier == RESPONSE_GET_INDUCTIONLOOP_VARIABLE &&
				*result.Contents == LAST_STEP_VEHICLE_DATA)
			{
				int32_t numPacks = 0;
				int j = 1;
				for (j; j < 4; ++j)
				{
					numPacks <<= 4;
					numPacks |= *(result.Contents + j);
				}
				for (int k = 0; k < numPacks; ++k)
				{
					// Vehicle ID
					++j; // type identifier
					int32_t idLength = 0;
					for (int l = 0; l < 4; ++l, ++j) {
						idLength <<= 4;
						idLength |= *(result.Contents + j);
					}
					++j; // type identifier
					j += 8; // Vehicle Length (double)
					++j; // type identifier
					j += 8; // Entry Time (double)
					++j; // type identifier
					j += 8; // Leave Time (double)
					++j; // type identifier
					// Vehicle Type ID (double)
					int32_t vehIdLength = 0;
					for (int l = 0; l < 4; ++l, ++j) {
						vehIdLength <<= 4;
						vehIdLength |= *(result.Contents + j);
					}
					char * vehIdString = (char*)malloc(sizeof(char) * (vehIdLength + 1));
					for (int l = 0; l < vehIdLength; ++l, ++j) {
						vehIdString[l] = *(result.Contents + j);
					}

					// Check!
					if (strcmp(vehTypeId, vehIdString) != 0) {
						return 1;
					}
				}
			}
		}
	}
	return 0;
}
*/

double TraCIGetLaneAreaLastStepOccupancy(const char * id)
{
    TraCICommand command;
    command.Identifier = CMD_GET_LANEAREA_VARIABLE;
    const unsigned int n = strlen(id);
    command.ContentsLength = 5 + n;
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
    *command.Contents = LAST_STEP_OCCUPANCY;
    *(command.Contents + 1) = (n >> 24) & 0xFF;
    *(command.Contents + 2) = (n >> 16) & 0xFF;
    *(command.Contents + 3) = (n >> 8) & 0xFF;
    *(command.Contents + 4) = n & 0xFF;
    for (int i = 5; i < command.ContentsLength; ++i)
    {
        *(command.Contents + i) = *(id + (i - 5));
    }

    const TraCIResults results = SendTraCIMessage(command);

    if (results.Count > 0)
    {
        for (int i = 0; i < results.Count; i++)
        {
	        const TraCIResult result = *(results.Results + i);
            if (result.Identifier == RESPONSE_GET_LANEAREA_VARIABLE &&
                *result.Contents == LAST_STEP_OCCUPANCY)
            {
                int32_t id_length = 0;
                for (int j = 0; j < 4; ++j) {
                    id_length <<= 4;
                    id_length |= *(result.Contents + j + 1);
                }
                unsigned char type = *(result.Contents + 5 + id_length);
                double per_occ = 0;
                unsigned char dbl[8];
                dbl[7] = *(result.Contents + 6 + id_length);
                dbl[6] = *(result.Contents + 7 + id_length);
                dbl[5] = *(result.Contents + 8 + id_length);
                dbl[4] = *(result.Contents + 9 + id_length);
                dbl[3] = *(result.Contents + 10 + id_length);
                dbl[2] = *(result.Contents + 11 + id_length);
                dbl[1] = *(result.Contents + 12 + id_length);
                dbl[0] = *(result.Contents + 13 + id_length);
                memcpy(&per_occ, dbl, 8);
            	
				FreeCommand(command);
				FreeResults(results);

            	return per_occ;
            }
        }
    }

	FreeCommand(command);
	FreeResults(results);
	
    return -1;
}

void TraCISetTrafficLightState(const char * trafficLightId, const char * state)
{
    TraCICommand command;
    command.Identifier = CMD_SET_TL_VARIABLE;
    const int id_len = strlen(trafficLightId);
    const int st_len = strlen(state);
    command.ContentsLength = 10 + id_len + st_len;
    command.Contents = (unsigned char *)malloc(sizeof(unsigned char) * command.ContentsLength);
    *command.Contents = TL_RED_YELLOW_GREEN_STATE;
    *(command.Contents + 1) = (id_len >> 24) & 0xFF;
    *(command.Contents + 2) = (id_len >> 16) & 0xFF;
    *(command.Contents + 3) = (id_len >> 8) & 0xFF;
    *(command.Contents + 4) = id_len & 0xFF;
    int i = 5;
    for (; i < id_len + 5; i++)
    {
        *(command.Contents + i) = *(trafficLightId + (i - 5));
    }
    *(command.Contents + i) = TYPE_STRING;
    *(command.Contents + i + 1) = (st_len >> 24) & 0xFF;
    *(command.Contents + i + 2) = (st_len >> 16) & 0xFF;
    *(command.Contents + i + 3) = (st_len >> 8) & 0xFF;
    *(command.Contents + i + 4) = st_len & 0xFF;
    const int p = id_len + st_len + 10;
    int k = 0;
    for (i = i + 5; i < p; i++)
    {
        *(command.Contents + i) = *(state + k);
        k++;
    }

    const TraCIResults results = SendTraCIMessage(command);

	FreeCommand(command);
	FreeResults(results);
}

TraCIResults SendTraCIMessage(TraCICommand command)
{
    if (!Connected)
    {
	    const TraCIResults results = { -1, NULL };
        return results;
    }

    int message_length = GetMessageBytes(command, OutgoingBytesBuffer);
    
    iResult = send(ConnectSocket, OutgoingBytesBuffer, message_length, 0);
    if (iResult == SOCKET_ERROR) {
        printf("send failed with error: %d\n", WSAGetLastError());
        const TraCIResults results = { -2, NULL };
        return results;
    }

    iResult = recv(ConnectSocket, IncomingBytesBuffer, MAXTCPBUFFER, 0);
    if (iResult > 0)
    {
        message_length = 0;
        for (int i = 0; i < 4; i++) {
            message_length <<= 4;
            message_length |= IncomingBytesBuffer[i];
        }

        TraCIResults results;

        TraCIResult temp[32];
        int result_index = 0;
        for (int cur_index = 4; cur_index < message_length; )
        {
            int cur_msg_index = 0;
            const int len = IncomingBytesBuffer[cur_index + cur_msg_index++];
            if (len == 0)
            {
                if (cur_msg_index + 3 < len)
                {
                    int32_t _curMsgLength = 0;
                    for (int i = 0; i < 4; i++) {
                        _curMsgLength <<= 4;
                        _curMsgLength |= IncomingBytesBuffer[cur_index + cur_msg_index + i];
                    }
                    temp[result_index].ContentsLength = _curMsgLength - 6;
                    cur_msg_index += 4;
                }
                else
                {
                    break;
                }
            }
            else
            {
                temp[result_index].ContentsLength = len - 2; // bytes lenght will be: msg - length - id
            }
            if (temp[result_index].ContentsLength > 0)
                temp[result_index].Contents = (unsigned char *)malloc(sizeof(unsigned char) * temp[result_index].ContentsLength);
            temp[result_index].Identifier = (unsigned char)IncomingBytesBuffer[cur_index + cur_msg_index++];
            int k = 0;
            while (cur_msg_index < len)
            {
                *(temp[result_index].Contents + k) = IncomingBytesBuffer[cur_index + cur_msg_index++];
                k++;
            }
            cur_index += cur_msg_index;
            result_index++;
        }
        TraCIResult * ttemp = (TraCIResult *)malloc(sizeof(TraCIResult) * (result_index + 1));
        for (int i = 0; i < result_index; i++)
        {
            *(ttemp + i) = temp[i];
        }
        results.Count = result_index;
        results.Results = ttemp;
        return results;
    }
    printf("receive failed with error: %d\n", WSAGetLastError());
    const TraCIResults results = { -2, NULL };
    return results;
}

static void FreeResults(TraCIResults results)
{
	for (int i = 0; i < results.Count; i++)
    {
	    const TraCIResult result = *(results.Results + i);
        if (result.ContentsLength > 0)
            free(result.Contents);
    }
    free(results.Results);
}

static void FreeCommand(TraCICommand command)
{
	if (command.ContentsLength > 0) free(command.Contents);
}

static int GetMessageBytes(TraCICommand command, char * bytesBuffer)
{
    TraCICommand * commands = (TraCICommand *)malloc(sizeof(TraCICommand));
    *commands = command;
    const int bytesNum = GetMessagesBytes(commands, 1, bytesBuffer);
    free(commands);
    return bytesNum;
}

static int GetMessagesBytes(TraCICommand * commands, int commandsCount, char * bytesBuffer)
{
    int curIndex = 4;
    for (int curCommandIndex = 0; curCommandIndex < commandsCount; ++curCommandIndex)
    {
	    const TraCICommand curCommand = *(commands + curCommandIndex);
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
            const int n = curCommand.ContentsLength + 6;
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
	    const int n = curCommand.ContentsLength + 6;
        *(bytesBuffer + 3) = n & 0xFF;
        *(bytesBuffer + 2) = (n >> 8) & 0xFF;
        *(bytesBuffer + 1) = (n >> 16) & 0xFF;
        *(bytesBuffer) = (n >> 24) & 0xFF;
    }

    return curIndex;
}