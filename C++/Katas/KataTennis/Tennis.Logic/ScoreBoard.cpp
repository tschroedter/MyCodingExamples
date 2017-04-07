#include "include/Player.h"
#include "include/ScoreBoard.h"
#include <iostream>

namespace Tennis
{
    namespace Logic
    {
        // todo maybe use IMatch as parameter so we can avoid printing 0 current score when Match was won

        void padTo ( std::string& str, const size_t num, const char paddingChar = ' ' )
        {
            if ( num > str.size() )
            {
                std::string padding = "";
                padding.insert ( 0, num - str.size(), paddingChar );

                str.append ( padding );
            }
        }

        std::string ScoreBoard::get_player_name_to_display (
            const Player player ) const
        {
            // make sure displayed player names have fixed length
            std::string player_name = m_manager->get_player_name ( player );

            player_name = player_name.substr ( 0, PLAYER_NAME_MAX );

            padTo ( player_name, PLAYER_NAME_MAX, ' ' );

            return player_name;
        }

        std::string ScoreBoard::score_for_player_as_string ( const Player player ) const
        {
            std::string total_score = get_player_name_to_display ( player );

            if ( !m_sets )
            {
                return total_score + " Unknown";
            }

            total_score +=
                    " "
                    + m_scores_for_player_calculator->get_scores_for_player ( player,
                                                                              m_sets );

            return total_score;
        }

        void ScoreBoard::print ( std::ostream& out ) const
        {
            out << score_for_player_as_string ( One ) << '\n';
            out << score_for_player_as_string ( Two ) << '\n';
        }
    };
};
