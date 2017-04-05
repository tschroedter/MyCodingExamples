#include "include/ISet.h"
#include "include/Sets.h"

namespace Tennis
{
    namespace Logic
    {
        ISet* Sets::create_new_set () // todo testing
        {
            return new_item();
        }

        ISet* Sets::get_current_set () const // todo testing
        {
            return get_current_item();
        }

        ISet* Sets::get_set_at_index ( const size_t index ) const // todo testing
        {
            return ( *this ) [ index ];
        }

        size_t Sets::get_number_of_sets () const // todo testing
        {
            return get_length();
        }
    };
};
