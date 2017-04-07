#include "stdafx.h"
#include <gtest/gtest.h>
#include "ScoresForPlayerCalculator.h"
#include "MockICurrentPlayerScoreCalculator.h"
#include "MockICountPlayerGames.h"
#include "MockISets.h"
#include "MockISet.h"

TEST(ScoresForPlayerCalculator, get_scores_for_player_returns_string_for_single_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet mock_set {};
    MockISets mock_sets {};

    MockICurrentPlayerScoreCalculator* mock_calculator = new MockICurrentPlayerScoreCalculator{};
    std::unique_ptr<ICurrentPlayerScoreCalculator> calculator ( mock_calculator );

    MockICountPlayerGames* mock_count_player_games = new MockICountPlayerGames{};
    std::unique_ptr<ICountPlayerGames> count_player_games ( mock_count_player_games );

    ScoresForPlayerCalculator sut
    {
        std::move ( calculator ),
        std::move ( count_player_games )
    };

    EXPECT_CALL(mock_sets,
        get_number_of_sets())
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( static_cast<size_t> ( 1 ) ) );

    EXPECT_CALL(mock_sets,
        get_set_at_index(0))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( &mock_set ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One,&mock_set))
                                   .Times ( 1 )
                                   .WillOnce ( testing::Return ( "3" ) );

    EXPECT_CALL(*mock_calculator,
        get_current_score_for_player(One, &mock_set))
                                                     .Times ( 1 )
                                                     .WillOnce ( testing::Return ( "15" ) );

    // Act
    auto actual = sut.get_scores_for_player ( One,
                                              &mock_sets );

    // Assert
    EXPECT_EQ("3 15", actual);
}

TEST(ScoresForPlayerCalculator, get_scores_for_player_returns_string_for_multiple_sets)
{
    using namespace Tennis::Logic;

    // Arrange
    MockISet mock_set_one {};
    MockISet mock_set_two {};
    MockISets mock_sets {};

    MockICurrentPlayerScoreCalculator* mock_calculator = new MockICurrentPlayerScoreCalculator{};
    std::unique_ptr<ICurrentPlayerScoreCalculator> calculator ( mock_calculator );

    MockICountPlayerGames* mock_count_player_games = new MockICountPlayerGames{};
    std::unique_ptr<ICountPlayerGames> count_player_games ( mock_count_player_games );

    ScoresForPlayerCalculator sut
    {
        std::move ( calculator ),
        std::move ( count_player_games )
    };

    EXPECT_CALL(mock_sets,
        get_number_of_sets())
                             .Times ( 1 )
                             .WillOnce ( testing::Return ( static_cast<size_t> ( 2 ) ) );

    EXPECT_CALL(mock_sets,
        get_set_at_index(0))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( &mock_set_one ) );

    EXPECT_CALL(mock_sets,
        get_set_at_index(1))
                            .Times ( 1 )
                            .WillOnce ( testing::Return ( &mock_set_two ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One, &mock_set_one))
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( "6" ) );

    EXPECT_CALL(*mock_count_player_games,
        count_games(One, &mock_set_two))
                                        .Times ( 1 )
                                        .WillOnce ( testing::Return ( "6" ) );

    EXPECT_CALL(*mock_calculator,
        get_current_score_for_player(One, &mock_set_two))
                                                         .Times ( 1 )
                                                         .WillOnce ( testing::Return ( "15" ) );

    // Act
    auto actual = sut.get_scores_for_player ( One,
                                              &mock_sets );

    // Assert
    EXPECT_EQ("6 6 15", actual);
}
