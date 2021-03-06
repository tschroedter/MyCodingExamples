#include <algorithm>
#include "include/Game.h"
#include "include/GameFactory.h"
#include "include/Logger.h"

namespace Tennis
{
    namespace Logic
    {
        IGame* GameFactory::create ()
        {
            std::unique_ptr<IAwardPoints> award_points = m_factory->create();
            std::unique_ptr<IGameScore> game_score_one = std::make_unique<GameScore>();
            std::unique_ptr<IGameScore> game_score_two = std::make_unique<GameScore>();

            IGame* game = new Game{
                std::move ( award_points ),
                std::move ( game_score_one ),
                std::move ( game_score_two ) };

            return game;
        }

        void GameFactory::release ( IGame* game )
        {
            delete game;
        }
    }
}
