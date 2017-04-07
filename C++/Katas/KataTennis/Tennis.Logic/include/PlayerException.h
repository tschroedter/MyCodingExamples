#pragma once
#include <string>
#include "BaseException.h"

namespace Tennis
{
    namespace Logic
    {
        class PlayerException
                : public BaseException
        {
        public:
            explicit PlayerException (
                std::string error )
                : BaseException ( error )
            {
            }
        };
    };
};
