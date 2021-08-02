#pragma once

// Need to link with Ws2_32.lib, Mswsock.lib, and Advapi32.lib
#pragma comment (lib, "Ws2_32.lib")

typedef struct TraCICommandStruct
{
    unsigned char Identifier;
    int ContentsLength;
    unsigned char * Contents;
} TraCICommand;

typedef struct TraCIResultStruct
{
    unsigned char Identifier;
    int ContentsLength;
    unsigned char * Contents;
} TraCIResult;

typedef struct TraCIResultsStruct
{
    int Count;
    TraCIResult * Results;
} TraCIResults;

int TraCIConnect(char * hostname, char * port);
void TraCICloseConnection(void);

void TraCIControlSimStep();
void TraCISetOrder(int order);
int TraCIGetInductionLoopLastStepVehicleNumber(const char * id, const char * vehTypeId);
double TraCIGetLaneAreaLastStepOccupancy(const char * id);
void TraCISetTrafficLightState(const char * trafficLightId, const char * state);

TraCIResults SendTraCIMessage(TraCICommand command);

static void FreeResults(TraCIResults results);
static void FreeCommand(TraCICommand command);
static int GetMessageBytes(TraCICommand command, char * bytesBuffer);
static int GetMessagesBytes(TraCICommand * commands, int commandsCount, char * bytesBuffer);