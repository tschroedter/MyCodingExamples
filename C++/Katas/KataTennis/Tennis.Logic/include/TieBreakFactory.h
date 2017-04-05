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
        private:
            std::unique_ptr<ILogger> m_logger;

        public:
            TieBreakFactory ( std::unique_ptr<ILogger> logger )
                : m_logger ( std::move ( logger ) )
            {
            }

            ITieBreak* create () override;
            void release ( ITieBreak* tie_break ) override;
        };
    }
}
