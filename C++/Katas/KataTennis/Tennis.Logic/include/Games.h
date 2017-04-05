#pragma once
#include "IGameFactory.h"
#include "Container.h"
#include "IGames.h"

namespace Tennis
{
    namespace Logic
    {
        class Games
                : public Container<IGame, IGameFactory>
                  , public IGames
        {
        public:
            Games ( std::shared_ptr<IGameFactory> factory )
                : Container<IGame, IGameFactory> ( std::move ( factory ) )
            {
            }

            IGame* create_new_game () override;
            IGame* get_current_game () const override;
            IGame* get_game_at_index ( const size_t index ) const override;
            size_t get_number_of_games () const override;
        };
    };
};
