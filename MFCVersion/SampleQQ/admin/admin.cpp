#pragma once
#pragma execution_character_set("utf-8")
/// 本文件为utf-8 编码格式
#undef UNICODE

#include <winsock2.h>
#include <Ws2tcpip.h>
#include <cstdio>
#include <string>
#include <vector>
#include <iostream>
#include <sstream>
#include <atomic>
#include <thread>
// #include <mutex>

// link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
using namespace std;

typedef pair< sockaddr_in, unsigned int > AddrPkg;

const int MAX_BUF_LENGTH    = 512;
const int MAX_THREAD_NUM    = 5;
const int MAX_BAKCLOG_NUM   = 5;
const char DEFAULT_PORT[]   = "6666";
const int  DEFAULT_PORT_INT = 6666;

int getAddr(struct addrinfo *result, vector<AddrPkg> &addrList, vector<SOCKET> &socketList)
{
    addrList.clear();
    // Retrieve each address and print out the hex bytes
    for (struct addrinfo *ptr = result; ptr != NULL; ptr = ptr->ai_next)
    {
        if (ptr->ai_family == AF_INET)
        {
            addrList.push_back(
                make_pair(*(sockaddr_in *) ptr->ai_addr, ptr->ai_addrlen)
            );
            socketList.push_back(
                socket(ptr->ai_family, ptr->ai_socktype, ptr->ai_protocol)
            );
        }
    }
    return addrList.size();
}

string addr2String(sockaddr_in &addr)
{
    char ipStringBuffer[16];
    int ipBufferLength = 16;
    inet_ntop(AF_INET, &addr.sin_addr, ipStringBuffer, ipBufferLength);
    string str = ipStringBuffer;
    return str;
}

int listAddr(vector<AddrPkg> &addrList, const int &capability)
{
    cout << "IP List:" << endl;
    for (int i = 0; i < capability; i++)
    {
        string str = addr2String(addrList[i].first);
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

// client
__declspec(thread) SOCKET               accSock; // 服务器连接套接字
__declspec(thread) sockaddr_in          addrClient;
__declspec(thread) int                  portClient;
__declspec(thread) char                 ipStringBuffer[16];
__declspec(thread) DWORD                ipBufferLength = 16;
__declspec(thread) int                  len = sizeof(SOCKADDR);
__declspec(thread) int                  cnt;
__declspec(thread) char                 buf[MAX_BUF_LENGTH];


void runAdmin(SOCKET __server, const int& adminID)
{
    string                cmd;
    ostringstream        strout;        //字符串输出流对象
    memset(buf, 0, sizeof(buf));
    do
    {
        // 4.等待客户机连接请,建立连接套接字
        accSock = accept(__server, (SOCKADDR*)&addrClient, &len);
        if (accSock == INVALID_SOCKET) {
            printf("accept failed with error: %d\n", WSAGetLastError());
            system("pause");
        }
        if (accSock == INVALID_SOCKET) continue;

        //客户机IP地址
        inet_ntop(AF_INET, &addrClient.sin_addr, ipStringBuffer, ipBufferLength);

        //客户机临时端口
        portClient = htons(addrClient.sin_port);
        cout << "[S" << adminID << "] accept client [";
        cout << ipStringBuffer << ":" << portClient << "]" << endl;

        // 5.接收服务请求,处理服务,发送服务响应
        cnt = 0;
        while (1)
        {
            strout.str("");
            recv(accSock, buf, sizeof(buf), 0);        //从客户机接受服务请求
            cout << "[C" << adminID << "] " << buf << endl;
            if (strcmp(buf, "quit") == 0) break;        //如果接受到quit则退出
            strout << "echo #" << ++cnt;
            strout << ": [" << buf << "].";
            string ostr = strout.str();
            send(accSock, ostr.c_str(), ostr.length() + 1, 0);        //向服务器发送服务响应
        }

        cout << "Input \"quit\" to shut down this thread, otherwise continue runing." << endl;
        cin >> cmd;
    } while (cmd != "quit");
    closesocket(accSock);
}

int main()
{
    WSADATA wsaData;
    int iResult;

    struct addrinfo *result = NULL;
    struct addrinfo *ptr = NULL;
    struct addrinfo hints;

    SOCKET server;        // 服务器TCP套接字

    // admin
    sockaddr_in addrAdmin;
    sockaddr_in bindAddr;
    int         portAdmin = DEFAULT_PORT_INT;


    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed: %d\n", iResult);
        return 1;
    }

    // 1.创建服务器TCP套接字
    //--------------------------------
    // Setup the hints address info structure
    // which is passed to the getaddrinfo() function
    ZeroMemory(&hints, sizeof(hints));
    hints.ai_family = AF_UNSPEC;
    hints.ai_socktype = SOCK_STREAM;
    hints.ai_protocol = IPPROTO_TCP;
    hints.ai_flags = AI_PASSIVE;

    // 2.绑定关联地址和协议端口
    ZeroMemory(&bindAddr, sizeof(bindAddr));
    bindAddr.sin_family = AF_INET;        //使用TCP/IP协议
    bindAddr.sin_addr.s_addr = htonl(INADDR_ANY);
    bindAddr.sin_port = htons(portAdmin);        //服务器端口
    server = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    ::bind(server, (SOCKADDR*)&bindAddr, sizeof(bindAddr));

    char bufNodeName[128];
    memset(bufNodeName, 0, sizeof(bufNodeName));
    gethostname(bufNodeName, sizeof(bufNodeName));        //获取本机 (服务器) 主机名
    cout << bufNodeName << endl;

    iResult = getaddrinfo(bufNodeName, DEFAULT_PORT, &hints, &result);
    if (iResult != 0)
    {
        printf("getaddrinfo failed with error: %d\n", iResult);
        WSACleanup();
        return 1;
    }

    vector<AddrPkg> addrList;
    vector<SOCKET>  socketList;
    int addrAdminCapability = getAddr(result, addrList, socketList);
    if (addrAdminCapability == 0)
    {
        printf("No accessible IP Address.\n");
        return 2;
    }

    int addrAdminID = listAddr(addrList, addrAdminCapability);
    addrAdmin       = addrList[addrAdminID].first;
    server          = socketList[addrAdminID];    //Internet域.流式套接字TCP
    string ipString = addr2String(addrAdmin);
    printf("\tIPv4 address %s\n", ipString.c_str());//服务器IP地址

    addrAdmin.sin_family = AF_INET;
    addrAdmin.sin_port = htons(portAdmin);

    iResult = ::bind(server, (SOCKADDR*)&addrAdmin, sizeof(addrAdmin));
    freeaddrinfo(result);

    // 3.监听外来连接
    iResult = listen(server, MAX_BAKCLOG_NUM);
    if (iResult == SOCKET_ERROR) {
        printf("main listen failed with error: %d\n", WSAGetLastError());
        system("pause");
    }
    cout << "server @[" << ipString << "] waiting for connection..." << endl;

    // Multi-threading
    const int _THREAD_NUM = MAX_THREAD_NUM;
    std::thread threads[_THREAD_NUM];
    cout << "Spawning " << _THREAD_NUM << " threads..." << endl;
    for (int i = 0; i < _THREAD_NUM; i++)
    {
        threads[i] = std::thread(runAdmin, server, i + 1);
    }
    cout << "Done spawning threads! Now wait for them to join..." << endl;
    for (auto& t : threads) { t.join(); }
    std::cout << "All threads joined." << endl;
    
    // runAdmin(server);

    // 6.关闭套接字
    closesocket(server);
    WSACleanup();
    return 0;
}
