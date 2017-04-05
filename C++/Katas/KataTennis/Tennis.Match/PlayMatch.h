#pragma once

#include "ScoreBoard.h"

namespace Tennis
{
    namespace Match
    {
        class PlayMatch
        {
        private:
            static int get_int_1_or_2 ();
            static Logic::Player ask_which_player_won_point ();

        public:
            void run () const;
        };
    }
}
