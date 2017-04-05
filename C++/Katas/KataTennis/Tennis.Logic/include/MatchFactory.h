#pragma once

#pragma once
#include <memory>
#include "IMatch.h"
#include "IMatchFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchFactory
                : public IMatchFactory
        {
        public:
            MatchFactory ()
            {
            }

            ~MatchFactory ()
            {
            }

            std::unique_ptr<Tennis::Logic::IMatch> create () override;
        };
    }
}
