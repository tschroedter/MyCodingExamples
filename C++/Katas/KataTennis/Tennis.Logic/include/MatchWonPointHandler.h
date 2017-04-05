#pragma once
#pragma once
#include "Player.h"
#include "IMatchWonPointHandler.h"
#include "Sets.h"

namespace Tennis
{
    namespace Logic
    {
        class MatchWonPointHandler
            : public IMatchWonPointHandler
        {
        private:
            Sets* m_sets;

            bool is_tie_break_finsihed() const;
            void create_new_set_and_call_won_point(Player player) const;

        public:
            MatchWonPointHandler(Sets* sets)
                : m_sets(sets)
            {
            }

            ~MatchWonPointHandler()
            {
            }

            void won_point(const Player player) override;
        };
    };
};
