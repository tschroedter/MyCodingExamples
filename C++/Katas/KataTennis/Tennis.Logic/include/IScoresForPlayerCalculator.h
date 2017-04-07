#pragma once

#pragma once
#include "Player.h"
#include <string>

namespace Tennis
{
    namespace Logic
    {
        class ISets;

        class IScoresForPlayerCalculator
        {
        public:
            virtual ~IScoresForPlayerCalculator () = default;

            virtual std::string get_scores_for_player (
                const Player player,
                const ISets* sets ) const = 0;
        };
    }
}
