#pragma once
#include "ISet.h"
#include "TieBreakFactory.h"
#include "ISetFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class SetFactory
                : public ISetFactory
        {
        private:
            std::shared_ptr<IGameFactory> m_game_factory;
            std::shared_ptr<ITieBreakFactory> m_tie_break_factory;

        public:
            SetFactory (
                std::shared_ptr<IGameFactory> game_factory,
                std::shared_ptr<ITieBreakFactory> tie_break_factory )
                : m_game_factory ( std::move ( game_factory ) )
                , m_tie_break_factory ( std::move ( tie_break_factory ) )
            {
            }

            ~SetFactory ()
            {
                m_game_factory.reset();
                m_tie_break_factory.reset();
            }

            ISet* create () override;
            void release ( ISet* set ) override;
        };
    }
}
