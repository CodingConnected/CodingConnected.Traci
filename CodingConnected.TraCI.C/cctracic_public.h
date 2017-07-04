#pragma once

// Need to link with Ws2_32.lib, Mswsock.lib, and Advapi32.lib
#pragma comment (lib, "Ws2_32.lib")

typedef struct TraCICommandStruct
{
    char Identifier;
    int ContentsLength;
    char * Contents;
} TraCICommand;

typedef struct TraCIResultStruct
{
    char Identifier;
    int ContentsLength;
    char * Contents;
} TraCIResult;

typedef struct TraCIResultsStruct
{
    int Count;
    TraCIResult * Results;
} TraCIResults;

int TraCIConnect(char * hostname, char * port);
void TraCICloseConnection();

void TraCIControlSimStep();
TraCIResults SendTraCIMessage(TraCICommand command);

static void FreeResults(TraCIResults results);
static int GetMessageBytes(TraCICommand command, char * bytesBuffer);
static int GetMessagesBytes(TraCICommand * commands, int commandsCount, char * bytesBuffer);