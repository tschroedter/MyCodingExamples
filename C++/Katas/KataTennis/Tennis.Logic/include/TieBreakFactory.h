#pragma once

#include "TieBreak.h"
#include "ITieBreakFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class TieBreakFactory
                : public ITieBreakFactory
        {
        public:
            TieBreakFactory ()
            {
            }

            ITieBreak* create () override;
            void release ( ITieBreak* tie_break ) override;
        };
    }
}
