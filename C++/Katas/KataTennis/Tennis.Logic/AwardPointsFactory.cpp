#include "include/IAwardPoints.h"
#include <memory>
#include <iostream>
#include "include/Logger.h"
#include "include/AwardPoints.h"
#include "AwardPointsFactory.h"

namespace Tennis
{
    namespace Logic
    {
        std::unique_ptr<IAwardPoints> AwardPointsFactory::create () const
        {
            std::unique_ptr<ILogger> logger = std::make_unique<Logger> ( std::cout );
            std::unique_ptr<IAwardPoints> award_points = std::make_unique<AwardPoints> ( std::move ( logger ) );

            return award_points;
        }
    }
}
