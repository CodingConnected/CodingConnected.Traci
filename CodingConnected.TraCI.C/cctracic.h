#pragma once
#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <stdio.h>
#include "TraCIConstants.h"

#include "cctracic_public.h"

#define MAXTCPBUFFER 32768

WSADATA wsaData;
SOCKET ConnectSocket = INVALID_SOCKET;
struct addrinfo *result = NULL,
    *ptr = NULL,
    hints;
int iResult;

char * Port;
char * Hostname;

char Connected = 0;
char OutgoingBytesBuffer[MAXTCPBUFFER];
char IncomingBytesBuffer[MAXTCPBUFFER];