#pragma once
#include <string>
#include "include/Set.h"
#include "include/GamesCounter.h"
#include "include/PlayerNameManager.h"
#include "IMatch.h"
#include "Sets.h"

namespace Tennis
{
    namespace Logic
    {
        class ScoreBoard
        {
        private:
            const size_t PLAYER_NAME_MAX = 10;
            IPlayerNameManager* m_manager;
            IGamesCounter* m_counter;
            Sets* m_sets;
            IMatch* m_match;

            static std::string ScoreBoard::reduce_to_n_digits(
                std::string scores_for_player_one,
                size_t digits);
            std::string ScoreBoard::get_games_count_for_player (
                Player player,
                ISet* set ) const;
            std::string ScoreBoard::get_current_score_for_player (
                Player player,
                ISet* set ) const;

        public:
            ScoreBoard (
                IPlayerNameManager* manager,
                IGamesCounter* counter,
                Sets* set )
                : m_manager ( manager )
                , m_counter ( counter )
                , m_sets ( set )
            {
            }

            void print ( std::ostream& out ) const;

            std::string ScoreBoard::score_for_player_as_string (
                const Player player ) const;

            static bool ScoreBoard::was_tie_break_won_by_player (
                const ITieBreak* tie_break,
                const Player player );
        };
    };
};
