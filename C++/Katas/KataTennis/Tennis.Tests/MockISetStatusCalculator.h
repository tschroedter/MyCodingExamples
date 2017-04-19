#pragma once
#include <gtest/gtest.h>
#include <gmock/gmock-generated-function-mockers.h>
#include "ISetStatusCalculator.h"

class MockISetStatusCalculator
        :public Tennis::Logic::ISetStatusCalculator
{
public:
    // ReSharper disable CppOverridingFunctionWithoutOverrideSpecifier
    MOCK_CONST_METHOD1(get_status, const Tennis::Logic::SetStatus(const Tennis::Logic::ISet*));
    MOCK_CONST_METHOD1(get_status, const Tennis::Logic::SetStatus(const Tennis::Logic::ISet_Ptr));
    // ReSharper restore CppOverridingFunctionWithoutOverrideSpecifier
};
