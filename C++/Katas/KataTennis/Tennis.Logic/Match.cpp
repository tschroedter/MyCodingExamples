#include "include/MatchStatus.h"
#include "include/Match.h"
#include "include/Player.h"
#include "include/RequiredSetsToWin.h"

namespace Tennis
{
    namespace Logic
    {
        void Match::initialize ()
        {
            m_sets->create_new_set();
        }

        void Match::won_point ( Player player )
        {
            MatchStatus status = get_status();

            if ( status == MatchStatus_NotStarted ||
                status == MatchStatus_InProgress )
            {
                m_handler->won_point ( player );
            }
            else
            {
                m_logger->error ( "Match is finished!" );
            }
        }

        MatchStatus Match::get_status () const
        {
            return m_calculator->get_status();
        }

        RequiredSetsToWin Match::get_required_sets_to_win () const
        {
            return m_required_sets_to_win;
        }

        ISets* Match::get_sets () const // todo not nice, scoreboard needs it
        {
            return m_sets.get();
        }
    };
};
