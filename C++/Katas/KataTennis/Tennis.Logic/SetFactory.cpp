#include "include/Set.h"
#include "include/SetFactory.h"
#include "include/GamesCounter.h"
#include "include/Logger.h"
#include "include/SetWonPointHandler.h"
#include "include/SetStatusCalculator.h"

namespace Tennis
{
    namespace Logic
    {
        ISet* SetFactory::create ()
        {
            std::unique_ptr<IGamesCounter> counter_for_calculator = std::make_unique<GamesCounter>();

            std::unique_ptr<IGamesCounter> counter_for_handler = std::make_unique<GamesCounter>();

            std::unique_ptr<IGames> games = std::make_unique<Games> ( m_game_factory );

            std::unique_ptr<ITieBreak> tie_break = std::make_unique<TieBreak> ();

            std::unique_ptr<ISetWonPointHandler> handler =
                    std::make_unique<SetWonPointHandler> (
                                                          std::move ( counter_for_handler ),
                                                          games.get(),
                                                          tie_break.get() );

            std::unique_ptr<ISetStatusCalculator> calculator =
                    std::make_unique<SetStatusCalculator> (
                                                           std::move ( counter_for_calculator ),
                                                           games.get(),
                                                           tie_break.get() );

            ISet* set = new Set{
                std::move ( calculator ),
                std::move ( handler ),
                std::move ( games ),
                std::move ( tie_break ) };

            set->initialize();

            return set;
        }

        void SetFactory::release ( ISet* set )
        {
            delete set;
        }
    }
}
