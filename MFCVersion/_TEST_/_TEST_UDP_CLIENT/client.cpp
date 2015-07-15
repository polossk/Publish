#pragma once
#pragma execution_character_set("utf-8")

#define WIN32_LEAN_AND_MEAN
#include <Windows.h>
#include <winsock2.h>
#include <WS2tcpip.h>
#include <cstdlib>
#include <cstdio>
#include <string>
#include <sstream>
#include <iostream>
using namespace std;
//连接到winsock 2对应的lib文件：ws2_32.lib,mswsock.lib和advapi32.lib
#pragma comment (lib, "Ws2_32.lib")
#pragma comment (lib, "Mswsock.lib")
#pragma comment (lib, "AdvApi32.lib")
//定义默认的缓冲区长度和端口号

const int   MAX_BUF_LENGTH = 512;
const int   MAX_THREAD_NUM = 5;
const char  DEFAULT_PORT[] = "7777";
const int   DEFAULT_PORT_INT = 7777;

int LENGTH_FROM = sizeof(SOCKADDR);
const int LENGTH_TO = sizeof(SOCKADDR);



inline string inputServerAddress()
{
	string buf; cout << "[I] server: ";
	cin >> buf; getchar(); return buf;
}


// client
__declspec(thread) SOCKET               accSock; // 服务器连接套接字
__declspec(thread) sockaddr_in          addrServer;
__declspec(thread) sockaddr_in          addrClient;
__declspec(thread) int                  portClient;
__declspec(thread) char                 ipStringBuffer[16];
__declspec(thread) DWORD                ipBufferLength = 16;
__declspec(thread) int                  len = sizeof(SOCKADDR);
__declspec(thread) int                  piResult;
__declspec(thread) int                  pcnt;
__declspec(thread) int                  pii;
__declspec(thread) char                 buf[MAX_BUF_LENGTH];

void runClientSend(SOCKET __server, const int& serverID, sockaddr_in &addr)
{
	string msg;
	while (1)
	{
		piResult = 0;
		cout << "[I] message: ";
		getline(cin, msg);
		piResult = sendto(__server, msg.c_str(), msg.size() + 1, 0, (SOCKADDR*)&addr, LENGTH_TO);
		if (piResult == SOCKET_ERROR)
		{
			printf("sendto failed with error %d\n", WSAGetLastError());
			system("pause");
		}
		if (msg == "quit") break;
		piResult = recvfrom(__server, buf, sizeof(buf), 0, (SOCKADDR*)&addrServer, &LENGTH_FROM);
		if (piResult == SOCKET_ERROR)
		{
			printf("recvfrom failed with error %d\n", WSAGetLastError());
			system("pause");
		}
		cout << "[S] " << buf << endl;
	}
}




int main(int argc, char **argv)
{
	WSADATA wsaData;
	int iResult;

	// client
	sockaddr_in addrListenFrom;
	sockaddr_in addrListen2;
	sockaddr_in addrReceive;
	SOCKET clientListen;
	SOCKET clientReceive;


	SOCKET ConnectLessSocket = INVALID_SOCKET;
	struct addrinfo *result = NULL, hints;
	char *sendbuf = "this is a test";
	char recvbuf[MAX_BUF_LENGTH];
	int recvbuflen = MAX_BUF_LENGTH;
	//初始化套接字
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0) {
		printf("WSAStartup failed with error: %d\n", iResult);
		return 1;
	}
	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_UNSPEC;
	hints.ai_socktype = SOCK_DGRAM;
	hints.ai_protocol = IPPROTO_UDP;


	// Receiving Socket
	string strAddr = inputServerAddress();
	ZeroMemory(&addrReceive, sizeof(addrReceive));
	addrReceive.sin_family = AF_INET;
	addrReceive.sin_port = htons(DEFAULT_PORT_INT);
	iResult = inet_pton(AF_INET, strAddr.c_str(), &addrReceive.sin_addr);
	if (iResult != 1)
	{
		printf("inet_pton clientReceive failed with error %d\n", WSAGetLastError());
		system("pause");
	}

	clientReceive = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (clientReceive == INVALID_SOCKET)
	{
		printf("socket clientReceive failed with error %d\n", WSAGetLastError());
		system("pause");
	}


	runClientSend(clientReceive, 999, addrReceive);

	//关闭套接字
	closesocket(clientReceive);
	//释放资源
	WSACleanup();
	return 0;
}