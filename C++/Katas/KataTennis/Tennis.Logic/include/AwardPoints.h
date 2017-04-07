#pragma once
#include "Player.h"
#include "IAwardPoints.h"

namespace Tennis
{
    namespace Logic
    {
        class IGameScore;

        class AwardPoints
                : public IAwardPoints
        {
        public:
            AwardPoints ()
            {
            }

            ~AwardPoints ()
            {
            }

            void award_point (
                const Player player,
                IGameScore* scorePlayerOne,
                IGameScore* scorePlayerTwo ) override;
        };
    };
};
