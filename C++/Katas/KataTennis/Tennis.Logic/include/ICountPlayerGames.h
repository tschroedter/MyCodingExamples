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

            virtual int8_t calculate_games (
                const Player player,
                const ISet* set ) const = 0;
        };

        typedef std::shared_ptr<Logic::ICountPlayerGames> ICountPlayerGames_Ptr;
    };
};
