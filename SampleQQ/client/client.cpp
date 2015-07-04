#pragma once
#pragma execution_character_set("utf-8")
/// 本文件为utf-8 编码格式
#undef UNICODE

#include <winsock2.h>
#include <ws2tcpip.h>
#include <cstdio>
#include <string>
#include <vector>
#include <iostream>
#include <sstream>

// link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
using namespace std;

const int MAX_LENGTH = 512;

inline string inputAdminAddress()
{
	string buf; cout << "[I] server: ";
	cin >> buf; getchar(); return buf;
}

int main()
{
	WSADATA wsaData;
	int iResult;

	struct addrinfo *result = NULL;
	struct addrinfo *ptr = NULL;

	SOCKET client;

	// admin
	struct sockaddr_in	addrAdmin;
	int					portAdmin = 6666;

	// message
	string msg;
	char buf[MAX_LENGTH];

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0)
	{
		printf("WSAStartup failed: %d\n", iResult);
		return 1;
	}


	// 1.创建客户机 TCP套接字
	client = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
	string strAdminAddr = inputAdminAddress();
	addrAdmin.sin_family = AF_INET;
	inet_pton(AF_INET, strAdminAddr.c_str(), &addrAdmin.sin_addr);
	addrAdmin.sin_port = htons(portAdmin);


	// 2.初始化连接，连接请求
	if (connect(client, (SOCKADDR*)&addrAdmin, sizeof(addrAdmin)) == SOCKET_ERROR)
	{
		cout << "connect failed:" << WSAGetLastError() << endl;
		WSACleanup();
		return -1;
	}


	// 3.发送服务请求、接收服务响应
	while (1)
	{
		cout << "[I] message: ";
		getline(cin, msg);
		send(client, msg.c_str(), msg.size() + 1, 0);
		if (msg == "quit") break;
		recv(client, buf, sizeof(buf), 0);
		cout << "[S] " << buf << endl;
	}


	// 4.关闭套接字
	closesocket(client);
	WSACleanup();
	return 0;
}