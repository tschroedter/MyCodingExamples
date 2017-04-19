#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ICountPlayerGames.h"

class MockICountPlayerGames
        :public Tennis::Logic::ICountPlayerGames
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD2(
        count_games,
        std::string(const Tennis::Logic::Player player,
            const Tennis::Logic::ISet* set));
    MOCK_CONST_METHOD2(
        calculate_games,
        int8_t(const Tennis::Logic::Player player,
            const Tennis::Logic::ISet* set));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
