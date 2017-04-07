#pragma once
#include <string>
#include "BaseException.h"

namespace Tennis
{
    namespace Logic
    {
        class SetStatusException
            : public BaseException
        {
        public:
            explicit SetStatusException(
                std::string error)
                : BaseException(error)
            {
            }
        };
    };
};
