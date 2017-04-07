#pragma once
#include <memory>
#include "vector"
#include "ContainerException.h"
#include "IContainer.h"
#include "IContainerFactory.h"
#include <string>

namespace Tennis
{
    namespace Logic
    {
        template <class T, class TFactory>
        class Container
                : public IContainer<T>
        {
        protected:
            std::shared_ptr<TFactory> m_factory;
            T* m_current_item;
            std::vector<T*> m_items;

        public:
            static_assert(
                std::is_base_of<IContainerFactory<T>,
                                TFactory>::value,
                "TFactory must inherit from IContainerFactory<T>");

            Container ( std::shared_ptr<TFactory> factory )
                : m_factory ( std::move ( factory ) )
                , m_current_item ( nullptr )
            {
            }

            ~Container ()
            {
                for ( T* set : m_items )
                {
                    m_factory->release ( set );
                }

                m_items.clear();
            }

            T* new_item () override;
            T* get_current_item () const override;
            T* operator[] ( const size_t index ) const override;
            size_t get_length () const override;
        };

        template <class T, class TFactory>
        T* Container<T, TFactory>::new_item ()
        {
            m_current_item = m_factory->create();

            m_items.push_back ( m_current_item );

            return m_current_item;
        }

        template <class T, class TFactory>
        T* Container<T, TFactory>::get_current_item () const
        {
            return m_current_item;
        }

        template <class T, class TFactory>
        T* Container<T, TFactory>::operator[] ( const size_t index ) const
        {
            if (index < 0 || index >= m_items.size())
            {
                throw ContainerException ( "Given index "
                                          + std::to_string ( index )
                                          + " must be >= 0 and < "
                                          + std::to_string ( m_items.size() ) );
            }

            return (m_items.at(index));
        }

        template <class T, class TFactory>
        size_t Container<T, TFactory>::get_length () const
        {
            return m_items.size();
        }
    };
};
