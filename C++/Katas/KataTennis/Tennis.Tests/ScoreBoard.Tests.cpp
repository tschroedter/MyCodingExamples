#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoreBoard.h"
#include <gmock/gmock-generated-function-mockers.h>
#include <strstream>
#include "MockIGame.h"
#include "MockIPlayerNameManager.h"
#include "MockIGamesCounterr.h"
#include "MockISets.h"
#include "MockIScoresForPlayerCalculator.h"

void test_score_for_player_as_string_with_different_player_names (
    const std::string player_name,
    const std::string expected )
{
    using namespace Tennis::Logic;

    // Arrange
    std::unique_ptr<MockIScoresForPlayerCalculator> scores_for_player_calculator = std::make_unique<MockIScoresForPlayerCalculator>();
    MockIPlayerNameManager manager {};
    MockIGamesCounter counter {};

    ScoreBoard sut {
        std::move ( scores_for_player_calculator ),
        &manager,
        &counter,
        nullptr
    };

    EXPECT_CALL(manager, get_player_name(One))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( player_name ) );

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
    EXPECT_EQ(expected, actual);
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_is_null)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "Player One",
                                                                 "Player One Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_with_fixed_length_for_short_player_name)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "One",
                                                                 "One        Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_sets_with_fixed_length_for_long_player_name)
{
    test_score_for_player_as_string_with_different_player_names (
                                                                 "01234567890123456789",
                                                                 "0123456789 Unknown" );
}

TEST(ScoreBoard, score_for_player_as_string_returns_string_for_player_one)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISets sets {};

    MockIScoresForPlayerCalculator* mock_calculator = new MockIScoresForPlayerCalculator{};
    std::unique_ptr<MockIScoresForPlayerCalculator> scores_for_player_calculator ( mock_calculator );
    MockIPlayerNameManager manager {};
    MockIGamesCounter counter {};

    ScoreBoard sut {
        std::move ( scores_for_player_calculator ),
        &manager,
        &counter,
        &sets
    };

    EXPECT_CALL(manager, get_player_name(One))
                                              .Times ( 1 )
                                              .WillOnce ( testing::Return ( "Player One" ) );

    EXPECT_CALL(*mock_calculator, get_scores_for_player(One, &sets))
                                                                    .Times ( 1 )
                                                                    .WillOnce ( testing::Return ( "3 15" ) );

    // Act
    std::string actual = sut.score_for_player_as_string ( One );

    // Assert
    EXPECT_EQ("Player One 3 15", actual);
}
