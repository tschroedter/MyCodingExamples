#include "include/IGame.h"
#include "include/Games.h"

namespace Tennis
{
    namespace Logic
    {
        IGame* Games::create_new_game ()
        {
            return new_item();
        }

        IGame* Games::get_current_game () const
        {
            return get_current_item();
        }

        IGame* Games::get_game_at_index ( const size_t index ) const
        {
            return ( *this ) [ index ];
        }

        size_t Games::get_number_of_games () const
        {
            return get_length();
        }
    };
};
