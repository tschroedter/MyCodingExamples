//
// Tennis.Match.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "MemoryInfo.h"
#include "MemoryLeakTest.h"
#include "Logger.h"
#include "PlayMatch.h"
#include "BaseException.h"

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
    Tennis::Logic::Logger logger { std::cout };

    int return_value = 0;

    try
    {
        memory_leak_test();
        // play_match();
    }
    catch ( Tennis::Logic::BaseException exception )
    {
        logger.error (
                      "Abnormal termination: "
                      + exception.get_error()
                      + "\n" );

        return_value = 1;
    }
    catch ( ... )
    {
        logger.error ( "Abnormal termination!!!\n" );

        return_value = 1;
    }

    return return_value;
}
