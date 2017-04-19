#pragma once
#include "MatchStatus.h"
#include <memory>
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class IMatchStatusCalculator
        {
        public:
            virtual ~IMatchStatusCalculator () = default;

            virtual void initialize ( const ISets_Ptr sets ) = 0;
            virtual const MatchStatus get_status () const = 0;
        };

        typedef std::shared_ptr<IMatchStatusCalculator> IMatchStatusCalculator_Ptr;
    };
};
