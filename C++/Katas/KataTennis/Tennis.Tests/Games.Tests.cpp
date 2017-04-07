#include "stdafx.h"
#include <gtest/gtest.h>
#include "Games.h"
#include <memory>
#include "IAwardPointsFactory.h"
#include "AwardPointsFactory.h"
#include "GameFactory.h"

TEST(Games, create_new_game_returns_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory> ( std::move ( award_points_factory ) );
    Games sut { std::move ( factory ) };

    // Act
    IGame* actual = sut.create_new_game();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Games, create_new_game_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory> ( std::move ( award_points_factory ) );
    Games sut { std::move ( factory ) };

    // Act
    sut.create_new_game();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Games, get_number_of_games_returns_number_of_games)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory> ( std::move ( award_points_factory ) );
    Games sut { std::move ( factory ) };
    sut.new_item();
    sut.new_item();

    // Act
    size_t actual = sut.get_number_of_games();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Games, get_current_game_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory> ( std::move ( award_points_factory ) );
    Games sut { std::move ( factory ) };
    sut.create_new_game();

    // Act
    auto actual = sut.get_current_game();

    // Assert
    EXPECT_NE(nullptr, actual);
}
