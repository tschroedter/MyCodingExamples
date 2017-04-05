#include "stdafx.h"
#include <string>
#include <gtest/gtest.h>
#include "GamesCounter.h"
#include "MockIGames.h"
#include "IAwardPointsFactory.h"
#include "AwardPointsFactory.h"
#include "GameFactory.h"

void winOneGameForPlayer ( Tennis::Logic::IGame* game, Tennis::Logic::Player player )
{
    game->won_point ( player );
    game->won_point ( player );
    game->won_point ( player );
    game->won_point ( player );
}

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_one_for_one_game_won_by_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 1 );

    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory> ( std::move ( award_points_factory ) );
    Games games { std::move ( factory ) };
    games.new_item();
    winOneGameForPlayer ( games.get_current_item(), One );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       &games );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_two_for_one_game_won_by_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 0 );

    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games games { std::move ( factory ) };
    games.new_item();
    winOneGameForPlayer ( games.get_current_item(), One );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       &games );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_one_for_one_game_won_by_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 0 );

    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games games { std::move ( factory ) };
    games.new_item();
    winOneGameForPlayer ( games.get_current_item(), Two );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( One,
                                                       &games );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(GamesCounter, count_games_for_player_returns_number_of_games_won_by_player_two_for_one_game_won_by_player_two)
{
    using namespace Tennis::Logic;

    // Arrange
    int8_t expected = static_cast<int8_t> ( 1 );

    std::unique_ptr<IAwardPointsFactory> award_points_factory = std::make_unique<AwardPointsFactory>();
    std::unique_ptr<GameFactory> factory = std::make_unique<GameFactory>(std::move(award_points_factory));
    Games games { std::move ( factory ) };
    games.new_item();
    winOneGameForPlayer ( games.get_current_item(), Two );

    GamesCounter sut {};

    // Act
    const int8_t actual = sut.count_games_for_player ( Two,
                                                       &games );

    // Assert
    EXPECT_EQ(expected, actual);
}
