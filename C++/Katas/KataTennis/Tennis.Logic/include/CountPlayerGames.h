#pragma once

#include "Player.h"
#include "ISet.h"
#include "IGamesCounter.h"
#include "ITieBreakWinnerCalculator.h"
#include "ICountPlayerGames.h"

namespace Tennis
{
    namespace Logic
    {
        class ISet;

        class CountPlayerGames
            : public ICountPlayerGames
        {
        private:
            std::unique_ptr<IGamesCounter> m_counter;
            std::unique_ptr<ITieBreakWinnerCalculator> m_calculator;

        public:
            CountPlayerGames (
                std::unique_ptr<IGamesCounter> counter,
                std::unique_ptr<ITieBreakWinnerCalculator> calculator )
                : m_counter ( std::move ( counter ) )
                , m_calculator ( std::move ( calculator ) )
            {
            }

            std::string count_games (
                const Player player,
                const ISet* set ) const override;
        };
    };
};
