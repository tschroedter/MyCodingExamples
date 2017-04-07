#include "include/IAwardPoints.h"
#include <memory>
#include "include/AwardPoints.h"
#include "include/AwardPointsFactory.h"

namespace Tennis
{
    namespace Logic
    {
        std::unique_ptr<IAwardPoints> AwardPointsFactory::create () const
        {
            std::unique_ptr<IAwardPoints> award_points = std::make_unique<AwardPoints> ();

            return award_points;
        }
    }
}
