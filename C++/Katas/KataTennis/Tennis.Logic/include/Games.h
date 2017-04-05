#pragma once
#include "IGameFactory.h"
#include "Container.h"

namespace Tennis
{
    namespace Logic
    {
        class Games
                : public Container<IGame, IGameFactory>
        {
        public:
            Games ( std::shared_ptr<IGameFactory> factory )
                : Container<IGame, IGameFactory> ( std::move ( factory ) )
            {
            }
        };
    };
};
