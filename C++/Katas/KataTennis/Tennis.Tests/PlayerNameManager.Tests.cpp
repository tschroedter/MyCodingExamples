#include "stdafx.h"
#include <string>
#include <gtest/gtest.h>
#include "PlayerNameManager.h"
#include "MockILogger.h"
#include "PlayerException.h"

TEST(PlayerNameManager, constructor_sets_name_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut
    {
        "Player One",
        "Player Two"
    };

    // Act
    std::string actual = sut.get_player_name ( One );

    // Assert
    EXPECT_EQ("Player One", actual);
}

TEST(PlayerNameManager, constructor_sets_name_for_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut
    {
        "Player One",
        "Player Two"
    };

    // Act
    std::string actual = sut.get_player_name ( Two );

    // Assert
    EXPECT_EQ("Player Two", actual);
}

TEST(PlayerNameManager, get_player_name_throws_for_unknown_player)
{
    using namespace Tennis::Logic;

    // Arrange
    PlayerNameManager sut
    {
        "Player One",
        "Player Two"
    };

    // Act
    // Assert
    EXPECT_THROW(
        sut.get_player_name(static_cast<Player> (-1)),
        Tennis::Logic::PlayerException);
}
