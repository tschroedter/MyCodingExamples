#pragma once

#include <cstdint>
#include "Games.h"
#include "IGamesCounter.h"

namespace Tennis
{
    namespace Logic
    {
        class GamesCounter
                : public IGamesCounter
        {
        public:
            int8_t count_games_for_player (
                const Player player,
                const Games* games ) override;
        };
    };
};
