#pragma once

#pragma once
#include <memory>
#include "IMatch.h"
#include "MatchStatusCalculator.h"
#include "MatchWonPointHandler.h"
#include "MatchCounter.h"
#include "Sets.h"
#include <iostream>
#include "Logger.h"
#include "Match.h"
#include "IMatchFactory.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchFactory // todo testing
                : public IMatchFactory
        {
        public:
            MatchFactory ()
            {
            }

            ~MatchFactory ()
            {
            }

            std::unique_ptr<Tennis::Logic::IMatch> create() override;
        };
    }
}
