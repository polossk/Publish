#pragma once
#pragma execution_character_set("utf-8")
/// 本文件为utf-8 编码格式
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

using namespace std;

void runMtimes(int m)
{
    std::chrono::steady_clock::time_point bng = std::chrono::steady_clock::now();
    while (1)
    {
        std::chrono::steady_clock::time_point fin = std::chrono::steady_clock::now();
        auto cnt = std::chrono::duration_cast<std::chrono::seconds>(fin - bng).count();
        cout << "passed [" << cnt << "s]." << endl;
        auto pre = std::chrono::duration_cast<std::chrono::milliseconds>(fin - bng).count();
        cout << "\tpassed [" << pre << "ms]." << endl;
        if (cnt >= m) return;
        Sleep(300);
    }
}

int main()
{
    runMtimes(5);
    system("pause");
    return 0;
}