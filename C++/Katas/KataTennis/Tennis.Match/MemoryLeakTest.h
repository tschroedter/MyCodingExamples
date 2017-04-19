#pragma once
#include "IIOCContainerBuilder.h"
#include "Match.h"

namespace Tennis
{
    namespace Match
    {
        class MemoryLeakTest
        {
        private:
            const static size_t POINTS_PER_GAME = 4;
            static void player_on_wins_tie_break ( Tennis::Logic::IMatch_Ptr match );
            static void print_status ( Tennis::Logic::IMatch_Ptr match );
            static void create_games_won (
                Tennis::Logic::IMatch_Ptr match,
                Logic::Player two,
                size_t games_scored_by_player_two );
            static void create_set_with_score (
                Tennis::Logic::IMatch_Ptr match,
                size_t games_scored_by_player_one,
                size_t games_scored_by_player_two );

            Container_Ptr m_container;

        public:
            MemoryLeakTest (
                Container_Ptr container )
                : m_container ( container )
            {
            }

            ~MemoryLeakTest ()
            {
            }

            void run () const;
        };
    }
}
