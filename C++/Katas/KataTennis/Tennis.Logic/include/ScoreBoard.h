#pragma once
#include <string>
#include "IMatch.h"
#include "Sets.h"
#include "IPlayerNameManager.h"
#include "IGamesCounter.h"
#include "IScoresForPlayerCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        class ScoreBoard
        {
        private:
            const size_t PLAYER_NAME_MAX = 10;

            std::unique_ptr<IScoresForPlayerCalculator> m_scores_for_player_calculator;
            IPlayerNameManager* m_manager;
            IGamesCounter* m_counter;
            ISets* m_sets;
            IMatch* m_match;

            std::string get_player_name_to_display ( const Player player ) const;
            
        public:
            ScoreBoard (
                std::unique_ptr<IScoresForPlayerCalculator> scores_for_player_calculator,
                IPlayerNameManager* manager,
                IGamesCounter* counter,
                ISets* set )
                : m_scores_for_player_calculator ( std::move ( scores_for_player_calculator ) )
                , m_manager ( manager )
                , m_counter ( counter )
                , m_sets ( set )
                , m_match ( nullptr )
            {
            }

            void print ( std::ostream& out ) const;

            std::string ScoreBoard::score_for_player_as_string (
                const Player player ) const;
        };
    };
};
