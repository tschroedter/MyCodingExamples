#include "include/ITieBreak.h"
#include "include/TieBreakFactory.h"

namespace Tennis
{
    namespace Logic
    {
        ITieBreak* TieBreakFactory::create ()
        {
            ITieBreak* tie_break = new TieBreak ();

            return tie_break;
        }

        void TieBreakFactory::release ( ITieBreak* tie_break )
        {
            delete tie_break;
        }
    }
}
