#pragma once
#include <memory>
#include "SetFactory.h"
#include "ISet.h"
#include "Container.h"
#include "ISets.h"

namespace Tennis
{
    namespace Logic
    {
        class Sets
                : public Container<ISet, ISetFactory>
                  , public ISets
        {
        public:
            Sets ( std::shared_ptr<ISetFactory> factory )
                : Container<ISet, ISetFactory> ( std::move ( factory ) )
            {
            }

            ISet* create_new_set () override;
            ISet* get_current_set () const override;
            ISet* get_set_at_index ( const size_t index ) const override;
            size_t get_number_of_sets () const override;
        };
    };
};
