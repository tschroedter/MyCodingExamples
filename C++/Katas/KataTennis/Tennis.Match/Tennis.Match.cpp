//
// Tennis.Match.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MemoryInfo.h"
#include "MemoryLeakTest.h"
#include "Logger.h"
#include "PlayMatch.h"

void memory_leak_test ()
{
    MemoryInfo mi {};
    mi.snapshot();

    std::cout << "Running memory leak test..." << "\n";

    int i = 0;
    while ( i < 1000 )
    {
        Tennis::Match::MemoryLeakTest test {};

        test.run();
        i++;
    }

    mi.snapshot();
    mi.calculate_deltas();
    mi.print_delta();
}

void play_match ()
{
    Tennis::Match::PlayMatch play_match {};

    play_match.run();
}

int main ()
{
    memory_leak_test();

    // play_match();

    return 0;
}
