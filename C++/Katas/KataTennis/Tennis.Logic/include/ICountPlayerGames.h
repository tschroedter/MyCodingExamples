#pragma once

#include "Player.h"
#include "ISet.h"

namespace Tennis
{
    namespace Logic
    {
        class ICountPlayerGames
        {
        public:
            virtual ~ICountPlayerGames () = default;

            virtual std::string count_games (
                const Player player,
                const ISet* set ) const = 0;
        };
    };
};
