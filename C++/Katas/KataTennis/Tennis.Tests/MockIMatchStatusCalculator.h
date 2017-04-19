#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "IMatchStatusCalculator.h"

class MockIMatchStatusCalculator
        :public Tennis::Logic::IMatchStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD0(get_status, const Tennis::Logic::MatchStatus());
    MOCK_METHOD1(initialize, void(const Tennis::Logic::ISets_Ptr));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
