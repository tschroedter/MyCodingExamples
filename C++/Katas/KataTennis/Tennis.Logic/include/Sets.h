#pragma once
#include <memory>
#include "SetFactory.h"
#include "ISet.h"
#include "Container.h"

namespace Tennis
{
    namespace Logic
    {
        class Sets
                : public Container<ISet, ISetFactory>
        {
        public:
            Sets(std::shared_ptr<ISetFactory> factory)
                : Container<ISet, ISetFactory>(std::move(factory))
            {
            }
        };
    };
};
