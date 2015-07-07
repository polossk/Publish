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

// link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
using namespace std;

typedef pair< sockaddr_in, unsigned int > AddrPkg;

const int   MAX_BUF_LENGTH      = 512;
const int   MAX_THREAD_NUM      = 5;
const int   MAX_BAKCLOG_NUM     = 5;
const char  DEFAULT_PORT[]      = "7777";
const int   DEFAULT_PORT_INT    = 7777;
const char  BROADCAST_PORT[]    = "7979";
const int   BROADCAST_PORT_INT  = 7979;

int LENGTH_FROM       = sizeof(SOCKADDR);
const int LENGTH_TO   = sizeof(SOCKADDR);


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
__declspec(thread) int                  piResult;
__declspec(thread) char                 buf[MAX_BUF_LENGTH];


void runServerBroadcast(SOCKET __server, const int& serverID,
    const sockaddr_in& addrServer, const string& msg)
{
    bool bOpt = true;
    piResult = 0;
    piResult = setsockopt(__server, SOL_SOCKET, SO_BROADCAST, (char*)&bOpt, sizeof(bOpt));
    if (piResult == SOCKET_ERROR)
    {
        printf("setsockopt failed with error %d\n", WSAGetLastError());
        system("pause");
    }
    ostringstream strout; strout.str("");
    strout << msg << endl;
    string ostr = strout.str();
    while (1)
    {
        piResult = sendto(
            __server, ostr.c_str(), ostr.size() + 1, 0,
            (SOCKADDR*)&addrServer, LENGTH_TO
            );
        if (piResult == SOCKET_ERROR)
        {
            printf("sendto failed with error %d\n", WSAGetLastError());
            system("pause");
        }
        cout << "[Broadcast #" << serverID << "]: " << msg << endl;
        Sleep(500);
    }
}

void runServerReceiver(SOCKET __server, const int& serverID)
{
    ostringstream strout; strout.str("");
    memset(buf, 0, sizeof(buf));
    while (1)
    {
        piResult = 0;
        piResult = recvfrom(__server, buf, sizeof(buf), 0, (SOCKADDR*)&addrClient, &LENGTH_FROM);
        if (piResult == SOCKET_ERROR)
        {
            printf("recvfrom failed with error %d\n", WSAGetLastError());
            system("pause");
        }
        // 客户机IP地址
        inet_ntop(AF_INET, &addrClient.sin_addr, ipStringBuffer, ipBufferLength);
        // 客户机临时端口
        portClient = htons(addrClient.sin_port);
        cout << "[S" << serverID << "] received message from client [";
        cout << ipStringBuffer << ":" << portClient << "]" << endl;
        // 接收服务请求,处理服务,发送服务响应
        cout << "[C" << serverID << "] " << buf << endl;
        if (strcmp(buf, "quit") == 0) break;        //如果接受到quit则退出
        strout.str(""); strout << "echo: [" << buf << "].";
        string ostr = strout.str();
        sendto(
            __server, ostr.c_str(), ostr.size() + 1, 0,
            (SOCKADDR*)&addrClient, LENGTH_TO
        );        //向服务器发送服务响应
    }
}

int main()
{
    WSADATA wsaData;
    int iResult;

    struct addrinfo *result = NULL;
    struct addrinfo *ptr = NULL;
    struct addrinfo hints;

    // server
    sockaddr_in bindAddrBroadcast;
    sockaddr_in bindAddrReceive;
    SOCKET serverBroadcast;
    SOCKET serverReceive;

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
    hints.ai_socktype = SOCK_DGRAM;
    hints.ai_protocol = IPPROTO_UDP;
    hints.ai_flags = AI_PASSIVE;

    // receive
    ZeroMemory(&bindAddrReceive, sizeof(bindAddrReceive));
    bindAddrReceive.sin_family = AF_INET;
    bindAddrReceive.sin_addr.s_addr = htonl(INADDR_ANY);
    bindAddrReceive.sin_port = htons(DEFAULT_PORT_INT);
    serverReceive = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    ::bind(serverReceive, (SOCKADDR*)&bindAddrReceive, sizeof(bindAddrReceive));


    // broadcast
    ZeroMemory(&bindAddrBroadcast, sizeof(bindAddrBroadcast));
    bindAddrBroadcast.sin_family = AF_INET;
    bindAddrBroadcast.sin_addr.s_addr = htonl(INADDR_BROADCAST);
    bindAddrBroadcast.sin_port = htons(BROADCAST_PORT_INT);
    serverBroadcast = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    ::bind(serverBroadcast, (SOCKADDR*)&bindAddrBroadcast, sizeof(bindAddrBroadcast));


    // get ip address
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
    int addrServerCapability = getAddr(result, addrList, socketList);
    if (addrServerCapability == 0)
    {
        printf("No accessible IP Address.\n");
        return 2;
    }

    int addrServerID    = listAddr(addrList, addrServerCapability);
    string ipString = addr2String(addrList[addrServerID].first);
    printf("\tIPv4 address %s\n", ipString.c_str());//服务器IP地址
    freeaddrinfo(result);

    

    cout << "Start Broadcast." << endl;
    // std::thread t0(runServerBroadcast, serverBroadcast, 0, bindAddrBroadcast, ipString);
    Sleep(100);
    // Multi-threading
    const int _THREAD_NUM = 1; // MAX_THREAD_NUM;
    std::thread threads[_THREAD_NUM];
    cout << "Spawning " << _THREAD_NUM << " threads..." << endl;
    for (int i = 0; i < _THREAD_NUM; i++)
    {
        threads[i] = std::thread(runServerReceiver, serverReceive, i + 1);
    }
    cout << "Done spawning threads! Now wait for them to join..." << endl;
    // t0.join();
    for (auto& t : threads) { t.join(); }
    cout << "All threads joined." << endl;

    // runServer(server);

    // 6.关闭套接字
    closesocket(serverReceive);
    closesocket(serverBroadcast);
    WSACleanup();
    return 0;
}
