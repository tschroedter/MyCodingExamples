#include "include/IGame.h"
#include "include/Games.h"

namespace Tennis
{
    namespace Logic
    {
        IGame* Games::create_new_game () // todo testing
        {
            return new_item();
        }

        IGame* Games::get_current_game () const // todo testing
        {
            return get_current_item();
        }

        IGame* Games::get_game_at_index ( const size_t index ) const // todo testing
        {
            return ( *this ) [ index ];
        }

        size_t Games::get_number_of_games () const // todo testing
        {
            return get_length();
        }
    };
};
