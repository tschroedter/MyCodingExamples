#include "Sets.h"
#include <cassert>

namespace Tennis
{
    namespace Logic
    {
        // todo create generic/template, see Games
        ISet* Sets::new_set ()
        {
            m_current_set = m_factory->create();

            m_sets.push_back ( m_current_set );

            return m_current_set;
        }

        ISet* Sets::get_current_set () const
        {
            return m_current_set;
        }

        ISet* Sets::operator[] ( const size_t index ) const
        {
            assert(index >= 0 && index < m_sets.size());

            return ( m_sets.at ( index ) );
        }

        size_t Sets::get_length () const
        {
            return m_sets.size();
        }
    };
};
