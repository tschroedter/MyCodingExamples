#pragma once

#include "Player.h"
#include "ISet.h"

namespace Tennis
{
    namespace Logic
    {
        class ICurrentPlayerScoreCalculator
        {
        public:
            virtual ~ICurrentPlayerScoreCalculator () = default;

            virtual std::string get_current_score_for_player (
                const Player player,
                const ISet* set ) const =0;
        };
    };
};
