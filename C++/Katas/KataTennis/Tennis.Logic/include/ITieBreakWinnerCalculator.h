#pragma once

#include "ITieBreak.h"
#include "Player.h"

namespace Tennis
{
    namespace Logic
    {
        class ITieBreakWinnerCalculator
        {
        public:
            virtual ~ITieBreakWinnerCalculator () = default;

            virtual bool was_tie_break_won_by_player (
                const ITieBreak* tie_break,
                Player player ) const = 0;
        };
    };
};
