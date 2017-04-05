#pragma once
#include "IMatch.h"
#include "RequiredSetsToWin.h"
#include "Player.h"
#include <memory>
#include "Sets.h"
#include "IMatchStatusCalculator.h"
#include "IMatchWonPointHandler.h"

namespace Tennis
{
    namespace Logic
    {
        class Match
                : public IMatch
        {
        private:
            std::unique_ptr<IMatchWonPointHandler> m_handler;
            std::unique_ptr<IMatchStatusCalculator> m_calculator;
            RequiredSetsToWin m_required_sets_to_win;
            std::unique_ptr<ISets> m_sets;
            std::unique_ptr<ILogger> m_logger;

        public:
            Match (
                std::unique_ptr<ILogger> logger,
                std::unique_ptr<IMatchWonPointHandler> handler,
                std::unique_ptr<IMatchStatusCalculator> calculator,
                std::unique_ptr<ISets> sets,
                RequiredSetsToWin required_sets_to_win )
                : m_handler ( std::move ( handler ) )
                , m_calculator ( std::move ( calculator ) )
                , m_required_sets_to_win ( required_sets_to_win )
                , m_sets ( std::move ( sets ) )
                , m_logger ( std::move ( logger ) )
            {
            }

            ~Match ()
            {
            }

            void initialize () override;
            void won_point ( Player player ) override;
            MatchStatus get_status () const override;
            RequiredSetsToWin get_required_sets_to_win () const override;
            ISets* get_sets () const override;
        };
    };
};
