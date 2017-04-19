#include "include/Player.h"
#include "include/CountPlayerGames.h"
#include "include/ITieBreak.h"
#include <string>
#include "include/ISet.h"

namespace Tennis
{
    namespace Logic
    {
        int8_t CountPlayerGames::calculate_games (
            const Player player,
            const ISet* set ) const
        {
            int8_t count_games_for_player =
                    m_counter->count_games_for_player (
                                                       player,
                                                       set->get_games() );

            const ITieBreak_Ptr tie_break = set->get_tie_break();

            if ( m_calculator->was_tie_break_won_by_player ( tie_break, player ) )
            {
                count_games_for_player++;
            }

            return count_games_for_player;
        }

        std::string CountPlayerGames::count_games (
            const Player player,
            const ISet* set ) const
        {
            int8_t val = calculate_games ( player,
                                           set );

            return std::to_string ( val );
        }
    };
};
