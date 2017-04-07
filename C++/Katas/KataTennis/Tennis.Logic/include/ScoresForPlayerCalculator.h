#pragma once

#pragma once
#include "IScoresForPlayerCalculator.h"
#include "Player.h"
#include <string>
#include "ICountPlayerGames.h"
#include "ICurrentPlayerScoreCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        class ISets;

        class ScoresForPlayerCalculator
                : public IScoresForPlayerCalculator
        {
        private:
            std::unique_ptr<ICurrentPlayerScoreCalculator> m_current_player_score_calculator;
            std::unique_ptr<ICountPlayerGames> m_count_player_games;

        public:
            // todo maybe, set manager, games manager???
            ScoresForPlayerCalculator (
                std::unique_ptr<ICurrentPlayerScoreCalculator> current_player_score_calculator,
                std::unique_ptr<ICountPlayerGames> count_player_games )
                : m_current_player_score_calculator ( std::move ( current_player_score_calculator ) )
                , m_count_player_games ( std::move ( count_player_games ) )
            {
            }

            std::string get_scores_for_player (
                const Player player,
                const ISets* sets ) const override;
        };
    }
}
