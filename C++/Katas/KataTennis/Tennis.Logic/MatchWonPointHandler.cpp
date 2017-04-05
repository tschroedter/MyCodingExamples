#include "include/MatchWonPointHandler.h"

namespace Tennis
{
    namespace Logic
    {
        bool MatchWonPointHandler::is_tie_break_finsihed() const
        {
            ISet* current_set = m_sets->get_current_item();

            TieBreakStatus tie_break_status =
                current_set->get_tie_break_status();

            return tie_break_status == TieBreakStatus_PlayerOneWon ||
                tie_break_status == TieBreakStatus_PlayerTwoWon;
        }

        void MatchWonPointHandler::create_new_set_and_call_won_point(Player player) const
        {
            m_sets->new_item();
            m_sets->get_current_item()->won_point(player);
        }

        void MatchWonPointHandler::won_point(const Player player)
        {
            ISet* current_set = m_sets->get_current_item();

            SetStatus status = current_set->get_status();

            switch (status)
            {
            case SetStatus_InTieBreak:
                is_tie_break_finsihed()
                    ? create_new_set_and_call_won_point(player)
                    : current_set->won_point(player);
                break;
            case SetStatus_NotStarted:
            case SetStatus_InProgress:
                current_set->won_point(player);
                break;
            case SetStatus_PlayerOneWon:
            case SetStatus_PlayerTwoWon:
                create_new_set_and_call_won_point(player);
                break;
            default: // todo log error
                break;
            }
        }
    };
};
