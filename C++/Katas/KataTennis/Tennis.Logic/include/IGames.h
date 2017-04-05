#pragma once
#include "IGame.h"

namespace Tennis
{
    namespace Logic
    {
        class IGames
        {
        public:
            virtual ~IGames () = default;

            virtual IGame* create_new_game () = 0;
            virtual IGame* get_current_game () const = 0;
            virtual IGame* get_game_at_index ( const size_t index ) const = 0;
            virtual size_t get_number_of_games () const = 0;
        };
    };
};
