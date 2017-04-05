#include "stdafx.h"
#include <gtest/gtest.h>
#include "Games.h"
#include <memory>
#include "AwardPointsFactory.h"
#include "GameFactory.h"

TEST(Games, newGame_returns_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games sut { std::move ( factory ) };

    // Act
    IGame* actual = sut.new_item();

    // Assert
    EXPECT_NE(nullptr, &actual);
}

TEST(Games, newGame_adds_new_item)
{
    using namespace Tennis::Logic;

    // Arrange
    size_t expected { 1 };
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games sut { std::move ( factory ) };

    // Act
    sut.new_item();

    // Assert
    EXPECT_EQ(expected, sut.get_length());
}

TEST(Games, get_length_returns_number_of_games)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games sut { std::move ( factory ) };
    sut.new_item();
    sut.new_item();

    // Act
    size_t actual = sut.get_length();

    // Assert
    EXPECT_EQ(2, actual);
}

TEST(Games, getCurrentGame_returns_current_game)
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games sut { std::move ( factory ) };
    sut.new_item();

    // Act
    auto actual = sut.get_current_item();

    // Assert
    EXPECT_NE(nullptr, actual);
}
