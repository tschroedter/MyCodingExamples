#pragma once

#include "IGame.h"

namespace Tennis
{
    namespace Logic
    {
        class IGameFactory
        {
        public:
            virtual ~IGameFactory() = default;

            virtual IGame* create() const = 0;
            virtual void release(IGame* game) = 0;
        };
    }
}
