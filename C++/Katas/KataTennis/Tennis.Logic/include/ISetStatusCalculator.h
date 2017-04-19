#pragma once
#include "SetStatus.h"
#include <memory>
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class ISetStatusCalculator
        {
        public:
            virtual ~ISetStatusCalculator () = default;

            virtual const SetStatus get_status ( const ISet_Ptr set ) const = 0;
            virtual const SetStatus get_status ( const ISet* set ) const = 0; // todo CHECK this first maybe ISet_Ptr
        };

        typedef std::shared_ptr<ISetStatusCalculator> ISetStatusCalculator_Ptr;
    };
};
