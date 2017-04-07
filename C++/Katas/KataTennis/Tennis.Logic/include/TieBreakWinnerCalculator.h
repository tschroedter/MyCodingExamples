#pragma once

#include "ITieBreak.h"
#include "Player.h"
#include "ITieBreakWinnerCalculator.h"

namespace Tennis
{
    namespace Logic
    {

        class TieBreakWinnerCalculator
            : public ITieBreakWinnerCalculator
        {
        public:
            TieBreakWinnerCalculator()
            {
            }

            bool was_tie_break_won_by_player(
                const ITieBreak* tie_break,
                Player player) const override;
        };
    };
};