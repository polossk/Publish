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

int getAddr(struct addrinfo *result, vector<struct sockaddr_in> &addrList)
{
	addrList.clear();
	// Retrieve each address and print out the hex bytes
	for (struct addrinfo *ptr = result; ptr != NULL; ptr = ptr->ai_next)
	{
		if (ptr->ai_family == AF_INET)
			addrList.push_back(*(struct sockaddr_in *) ptr->ai_addr);
	}
	return addrList.size();
}

string addr2String(struct sockaddr_in &addr)
{
	char ipStringBuffer[16];
	int ipBufferLength = 16;
	inet_ntop(AF_INET, &addr.sin_addr, ipStringBuffer, ipBufferLength);
	string str = ipStringBuffer;
	return str;
}

int listAddr(vector<struct sockaddr_in> &addrList, const int &capability)
{
	cout << "IP List:" << endl;
	for (int i = 0; i < capability; i++)
	{
		string str = addr2String(addrList[i]);
		cout << "    [" << i + 1 << "]: " << str << endl;
	}
	cout << "Input the id of the selected IP address. id = ? ";
	int id = 0;
	while (cin >> id)
	{
		if (id > capability)
			cout << "Exceeded the boundary. Try again. id = ? ";
		else if (id <= 0)
			cout << "Wrong input. Try again. id = ? ";
		else return id - 1;
	}
	return -1;
}

int main()
{
	WSADATA wsaData;
	int iResult;
	DWORD dwRetval;

	struct addrinfo *result = NULL;
	struct addrinfo *ptr = NULL;
	struct addrinfo hints;

	SOCKET server, accSock;		//服务器TCP套接字，连接套接字

	// admin
	struct sockaddr_in	addrAdmin;
	struct sockaddr_in  bindAddr;
	int					portAdmin = 6666;

	// client
	struct sockaddr_in	addrClient;
	int					portClient;

	char ipStringBuffer[16];
	DWORD ipBufferLength = 16;

	int len = sizeof(SOCKADDR), count = 0;
	char buf[MAX_LENGTH];

	ostringstream strout;		//字符串输出流对象

	// Initialize Winsock
	iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
	if (iResult != 0)
	{
		printf("WSAStartup failed: %d\n", iResult);
		return 1;
	}

    // 1.创建服务器TCP套接字
    server = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);		//Internet域.流式套接字TCP

	//--------------------------------
	// Setup the hints address info structure
	// which is passed to the getaddrinfo() function
	ZeroMemory(&hints, sizeof(hints));
	hints.ai_family = AF_UNSPEC;
	hints.ai_socktype = SOCK_STREAM;
	hints.ai_protocol = IPPROTO_TCP;

	// 2.绑定关联地址和协议端口
	ZeroMemory(&bindAddr, sizeof(bindAddr));
	bindAddr.sin_family = AF_INET;		//使用TCP/IP协议
	bindAddr.sin_addr.s_addr = htonl(INADDR_ANY);
	bindAddr.sin_port = htons(portAdmin);		//服务器端口
	bind(server, (SOCKADDR*)&bindAddr, sizeof(bindAddr));

	char bufNodeName[128];
	memset(bufNodeName, 0, sizeof(bufNodeName));
	gethostname(bufNodeName, sizeof(bufNodeName));		//获取本机 (服务器) 主机名
	cout << bufNodeName << endl;

	dwRetval = getaddrinfo(bufNodeName, NULL, &hints, &result);

	if (dwRetval != 0)
	{
		printf("getaddrinfo failed with error: %d\n", dwRetval);
		WSACleanup();
		return 1;
	}

	vector<struct sockaddr_in> addrList;
	int addrAdminCapability = getAddr(result, addrList);
	if (addrAdminCapability == 0)
	{
		printf("No accessible IP Address.\n");
		return 2;
	}

	int addrAdminID = listAddr(addrList, addrAdminCapability);
	addrAdmin = addrList[addrAdminID];
	string ipString = addr2String(addrAdmin);
	printf("\tIPv4 address %s\n", ipString.c_str());//服务器IP地址
	freeaddrinfo(result);


	string cmd;
	do
	{
		// 3.监听外来连接
		listen(server, 1);
		cout << "server @[" << ipString << "] waiting for connection..." << endl;

		
		// 4.等待客户机连接请,建立连接套接字
		accSock = accept(server, (SOCKADDR*)&addrClient, &len);

		//客户机IP地址
		inet_ntop(AF_INET, &addrClient.sin_addr, ipStringBuffer, ipBufferLength);

		//客户机临时端口
		portClient = htons(addrClient.sin_port);
		cout << "[S] accept client [" << ipStringBuffer << ":" << portClient << "]" << endl;


		// 5.接收服务请求,处理服务,发送服务响应
		while (1)
		{
			strout.str("");
			recv(accSock, buf, sizeof(buf), 0);		//从客户机接受服务请求
			cout << "[C] " << buf << endl;
			if (strcmp(buf, "quit") == 0) break;		//如果接受到quit则退出
			strout << "echo" << ++count; string ostr = strout.str();
			send(accSock, ostr.c_str(), ostr.length() + 1, 0);		//向服务器发送服务响应
		}

		cout << "Input \"quit\" to shut down this program, otherwise continue runing." << endl;
		cin >> cmd;
	} while (cmd != "quit");


    // 6.关闭套接字
    closesocket(accSock);
    closesocket(server);
    WSACleanup();
    return 0;
}
