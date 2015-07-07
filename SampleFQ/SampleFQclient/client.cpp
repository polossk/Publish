#pragma once
#pragma execution_character_set("utf-8")
/// 本文件为utf-8 编码格式
#undef UNICODE

#include <winsock2.h>
#include <Ws2tcpip.h>
#include <ctime>
#include <chrono>
#include <cstdio>
#include <string>
#include <vector>
#include <iostream>
#include <iomanip>
#include <sstream>
#include <atomic>
#include <thread>
#include <future>

// link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
using namespace std;

const int   MAX_BUF_LENGTH      = 512;
const int   MAX_THREAD_NUM      = 5;
const int   MAX_BAKCLOG_NUM     = 5;
const char  DEFAULT_PORT[]      = "7777";
const int   DEFAULT_PORT_INT    = 7777;
const char  BROADCAST_PORT[]    = "7979";
const int   BROADCAST_PORT_INT  = 7979;

int LENGTH_FROM     = sizeof(SOCKADDR);
const int LENGTH_TO = sizeof(SOCKADDR);

void buildBeforeBind(sockaddr_in &addr, SOCKET &_socket, const int &port, bool isListen)
{
    ZeroMemory(&addr, sizeof(addr));
    addr.sin_family = AF_INET;
    addr.sin_addr.s_addr = htonl( isListen ? INADDR_BROADCAST : INADDR_ANY );
    addr.sin_port = htons(port);
    _socket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
}

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

string __coreClientListen(SOCKET __server, const int &serverID,
    sockaddr_in &msgSource)
{
    ostringstream strout; strout.str("");
    memset(buf, 0, sizeof(buf));
    piResult = recvfrom(__server, buf, sizeof(buf), 0, (SOCKADDR*)&msgSource, &LENGTH_FROM);
    if (piResult == SOCKET_ERROR)
    {
        printf("recvfrom failed with error %d\n", WSAGetLastError());
        return "";
    }
    // 广播站IP地址
    inet_ntop(AF_INET, &msgSource.sin_addr, ipStringBuffer, ipBufferLength);
    // 广播站临时端口
    portClient = htons(msgSource.sin_port);
    cout << "[S" << serverID << "] received message from server [";
    cout << ipStringBuffer << ":" << portClient << "]" << endl;
    // 接收服务请求,处理服务,发送服务响应
    cout << "[C" << serverID << "] " << buf << endl;
    strout.str("");
    strout << "echo: [" << buf << "].";
    string ostr = strout.str();
    sendto(
        __server, ostr.c_str(), ostr.size() + 1, 0,
        (SOCKADDR*)&msgSource, LENGTH_TO
    );
    return string(ipStringBuffer);
}

bool runClientListen(SOCKET __server, const int &serverID,
    sockaddr_in &msgSource)
{
    pcnt = 0;
    std::chrono::steady_clock::time_point bng = std::chrono::steady_clock::now();
    for (pii = 0; pii < 20; pii++)
    {
        std::future<string> futureTry = std::async(
            std::launch::async, __coreClientListen,
            __server, serverID, msgSource
        );
        cout << "begin test #" << pii << "." << endl;
        std::future_status futureTrySataus = futureTry.wait_for(
            std::chrono::milliseconds(700)
        );
        cout << "    Time out?" << endl;

        if (futureTrySataus == std::future_status::deferred) {
            std::cout << "        deferred\n";
        }
        else if (futureTrySataus == std::future_status::timeout) {
            std::cout << "        timeout\n";
        }
        else if (futureTrySataus == std::future_status::ready) {
            std::cout << "        ready!\n";
        }

        if (futureTrySataus == std::future_status::ready)
        {
            pcnt++;
            string ip = futureTry.get();
            cout << "get ip address: " << ip << endl;
        }
        else
            cout << "test #" << pii + 1 << " Failed." << endl;
        if (pcnt >= 5) return pcnt >= 5;
    }
    return false;
}

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

inline string inputAdminAddress()
{
    string buf; cout << "[I] server: ";
    cin >> buf; getchar(); return buf;
}


int main()
{
    WSADATA wsaData;
    int iResult;
    
    // client
    sockaddr_in addrListenFrom;
    sockaddr_in addrListen2;
    sockaddr_in addrReceive;
    SOCKET clientListen;
    SOCKET clientReceive;

    // Initialize Winsock
    iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
    if (iResult != 0)
    {
        printf("WSAStartup failed: %d\n", iResult);
        return 1;
    }

    // Receiving Socket
    string strAdminAddr = inputAdminAddress();
    ZeroMemory(&addrReceive, sizeof(addrReceive));
    addrReceive.sin_family = AF_INET;
    addrReceive.sin_port = htons(DEFAULT_PORT_INT);
    iResult = inet_pton(AF_INET, strAdminAddr.c_str(), &addrReceive.sin_addr);
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

    

    // Listening Socket
    ZeroMemory(&addrListen2, sizeof(addrListen2));
    addrListen2.sin_family = AF_INET;
    addrListen2.sin_addr.s_addr = htonl(INADDR_ANY);
    addrListen2.sin_port = htons(BROADCAST_PORT_INT);


    ZeroMemory(&addrListenFrom, sizeof(addrListenFrom));
    addrListenFrom.sin_family = AF_INET;
    addrListenFrom.sin_addr.s_addr = htonl(INADDR_BROADCAST);
    addrListenFrom.sin_port = htons(BROADCAST_PORT_INT);


    clientListen = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
    bool bOpt = true;
    iResult = setsockopt(clientListen, SOL_SOCKET, SO_BROADCAST, (char*)&bOpt, sizeof(bOpt));
    if (iResult == SOCKET_ERROR)
    {
        printf("setsockopt failed with error %d\n", WSAGetLastError());
        system("pause");
    }

    // bind address and socket
    iResult = ::bind(clientListen, (SOCKADDR*)&addrListen2, sizeof(addrListen2));
    if (iResult == SOCKET_ERROR)
    {
        printf("bind clientListen failed with error %d\n", WSAGetLastError());
        system("pause");
    }


    // runClientListen(clientListen, 0, addrListenFrom, test);
    runClientSend(clientReceive, 999, addrReceive);
    /*
    std::future<bool> run = std::async(
        std::launch::async, runClientListen,
        clientListen, 0, addrListenFrom
    );

    std::future_status runSataus = run.wait_for(
        std::chrono::seconds(15)
    );

    if (runSataus != std::future_status::ready)
    {
        cout << "Failed" << endl;
        closesocket(clientReceive);
        closesocket(clientListen);
        WSACleanup();
        system("pause");
    } else {
        cout << "Successful test, checking return value." << endl;
        bool flag = run.get();
        if (flag)
            cout << "Returned ture, ip address detected." << endl;
        else
            cout << "Returned false, test failed." << endl;
    }
    */
    

    // 3.关闭套接字
    closesocket(clientReceive);
    closesocket(clientListen);
    WSACleanup();
    system("pause");
    return 0;
}