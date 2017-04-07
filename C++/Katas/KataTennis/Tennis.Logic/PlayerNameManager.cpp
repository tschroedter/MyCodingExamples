#include "include/PlayerNameManager.h"
#include <string>
#include "include/PlayerException.h"

namespace Tennis
{
    namespace Logic
    {
        std::string PlayerNameManager::get_player_name ( Player player ) const
        {
            switch ( player )
            {
                case One :
                    return m_player_name_one;
                case Two :
                    return m_player_name_two;
                default :
                    throw PlayerException ( "Unknown Player type: " + std::to_string ( player ) );
            }
        }
    };
};
