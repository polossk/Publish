#pragma once
#pragma execution_character_set("utf-8")
/// 本文件为utf-8 编码格式
#undef UNICODE

#include <winsock2.h>
#include <ws2tcpip.h>
#include <stdio.h>

// link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")

int __cdecl main(int argc, char **argv)
{

	//-----------------------------------------
	// Declare and initialize variables
	WSADATA wsaData;
	int iResult;
	DWORD dwRetval;

	int i = 1;

	struct addrinfo *result = NULL;
	struct addrinfo *ptr = NULL;
	struct addrinfo hints;

	struct sockaddr_in  *sockAddrIPv4;
	struct sockaddr_in6 *sockAddrIPv6;

	char ipStringBuffer[46];
	DWORD ipBufferLength = 46;

	// Validate the parameters
	if (argc != 3) {
		printf("usage: %s <hostname> <servicename>\n", argv[0]);
		printf("getaddrinfo provides protocol-independent translation\n");
		printf("   from an ANSI host name to an IP address\n");
		printf("%s example usage\n", argv[0]);
		printf("   %s www.contoso.com 0\n", argv[0]);
		return 1;
	}

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0)
	{
		printf("WSAStartup failed: %d\n", iResult);
		return 1;
	}

	//--------------------------------
	// Setup the hints address info structure
	// which is passed to the getaddrinfo() function
	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_UNSPEC;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	printf("Calling getaddrinfo with following parameters:\n");
	printf("\tnodename = %s\n", argv[1]);
	printf("\tservname (or port) = %s\n\n", argv[2]);

	//--------------------------------
	// Call getaddrinfo(). If the call succeeds,
	// the result variable will hold a linked list
	// of addrinfo structures containing response
	// information
	dwRetval = getaddrinfo(argv[1], argv[2], &hints, &result);
	if (dwRetval != 0) {
		printf("getaddrinfo failed with error: %d\n", dwRetval);
		WSACleanup();
		return 1;
	}

	printf("getaddrinfo returned success\n");

	// Retrieve each address and print out the hex bytes
	for (ptr = result; ptr != NULL; ptr = ptr->ai_next) {

		printf("getaddrinfo response %d\n", i++);
		printf("\tFlags: 0x%x\n", ptr->ai_flags);
		printf("\tFamily: ");
		switch (ptr->ai_family) {
		case AF_UNSPEC:
			printf("Unspecified\n");
			break;
		case AF_INET:
			printf("AF_INET (IPv4)\n");
			sockAddrIPv4 = (struct sockaddr_in *) ptr->ai_addr;
			ipBufferLength = 16;
			inet_ntop(AF_INET, &sockAddrIPv4->sin_addr, ipStringBuffer, ipBufferLength);
			printf("\tIPv4 address %s\n", ipStringBuffer);
			break;
		case AF_INET6:
			printf("AF_INET6 (IPv6)\n");
			// the InetNtop function is available on Windows Vista and later
			sockAddrIPv6 = (struct sockaddr_in6 *) ptr->ai_addr;
			ipBufferLength = 46;
			inet_ntop(AF_INET6, &sockAddrIPv6->sin6_addr, ipStringBuffer, ipBufferLength);
			printf("\tIPv6 address %s\n", ipStringBuffer);
			break;
			// sockAddrIPv6 = (struct sockaddr_in6 *) ptr->ai_addr;
			// printf("\tIPv6 address %s\n",
			//    InetNtop(AF_INET6, &sockAddrIPv6->sin6_addr, ipStringBuffer, 46) );

		case AF_NETBIOS:
			printf("AF_NETBIOS (NetBIOS)\n");
			break;
		default:
			printf("Other %ld\n", ptr->ai_family);
			break;
		}
		printf("\tSocket type: ");
		switch (ptr->ai_socktype) {
		case 0:
			printf("Unspecified\n");
			break;
		case SOCK_STREAM:
			printf("SOCK_STREAM (stream)\n");
			break;
		case SOCK_DGRAM:
			printf("SOCK_DGRAM (datagram) \n");
			break;
		case SOCK_RAW:
			printf("SOCK_RAW (raw) \n");
			break;
		case SOCK_RDM:
			printf("SOCK_RDM (reliable message datagram)\n");
			break;
		case SOCK_SEQPACKET:
			printf("SOCK_SEQPACKET (pseudo-stream packet)\n");
			break;
		default:
			printf("Other %ld\n", ptr->ai_socktype);
			break;
		}
		printf("\tProtocol: ");
		switch (ptr->ai_protocol) {
		case 0:
			printf("Unspecified\n");
			break;
		case IPPROTO_TCP:
			printf("IPPROTO_TCP (TCP)\n");
			break;
		case IPPROTO_UDP:
			printf("IPPROTO_UDP (UDP) \n");
			break;
		default:
			printf("Other %ld\n", ptr->ai_protocol);
			break;
		}
		printf("\tLength of this sockaddr: %d\n", ptr->ai_addrlen);
		printf("\tCanonical name: %s\n", ptr->ai_canonname);
	}

	freeaddrinfo(result);
	WSACleanup();

	return 0;
}