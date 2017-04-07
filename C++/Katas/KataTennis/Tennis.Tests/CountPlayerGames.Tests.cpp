#include "stdafx.h"
#include <gtest/gtest.h>
#include "CountPlayerGames.h"
#include "MockIGamesCounterr.h"
#include "MockITieBreakWinnerCalculator.h"
#include "MockISet.h"
#include "MockITieBreak.h"
#include "MockIGames.h"

TEST(CountPlayerGames, get_games_count_for_player_returns_string_for_normal_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    MockISet mock_set {};
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockITieBreakWinnerCalculator* mock_calculator = new MockITieBreakWinnerCalculator{};
    std::unique_ptr<ITieBreakWinnerCalculator> calculator ( mock_calculator );

    CountPlayerGames sut {
        std::move ( counter ),
        std::move ( calculator )
    };

    EXPECT_CALL(*mock_counter,
        count_games_for_player(
            One,
            &mock_games))
                         .Times ( 1 )
                         .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(mock_set, get_games())
                                      .Times ( 1 )
                                      .WillOnce ( testing::Return ( &mock_games ) );

    EXPECT_CALL(mock_set, get_tie_break())
                                          .Times ( 1 )
                                          .WillOnce ( testing::Return ( &mock_tie_break ) );

    EXPECT_CALL(*mock_calculator,
        was_tie_break_won_by_player(
            &mock_tie_break,
            One))
                 .Times ( 1 )
                 .WillOnce ( testing::Return ( false ) );

    // Act
    auto actual = sut.count_games ( One,
                                                   &mock_set );

    // Assert
    EXPECT_EQ("6", actual);
}

TEST(CountPlayerGames, get_games_count_for_player_returns_string_for_tie_break_set)
{
    using namespace Tennis::Logic;

    // Arrange
    MockIGames mock_games {};
    MockITieBreak mock_tie_break {};
    MockISet mock_set {};
    MockIGamesCounter* mock_counter = new MockIGamesCounter{};
    std::unique_ptr<IGamesCounter> counter ( mock_counter );
    MockITieBreakWinnerCalculator* mock_calculator = new MockITieBreakWinnerCalculator{};
    std::unique_ptr<ITieBreakWinnerCalculator> calculator ( mock_calculator );

    CountPlayerGames sut {
        std::move ( counter ),
        std::move ( calculator )
    };

    EXPECT_CALL(*mock_counter,
        count_games_for_player(
            One,
            &mock_games))
                         .Times ( 1 )
                         .WillOnce ( testing::Return ( static_cast<int8_t> ( 6 ) ) );

    EXPECT_CALL(mock_set, get_games())
                                      .Times ( 1 )
                                      .WillOnce ( testing::Return ( &mock_games ) );

    EXPECT_CALL(mock_set, get_tie_break())
                                          .Times ( 1 )
                                          .WillOnce ( testing::Return ( &mock_tie_break ) );

    EXPECT_CALL(*mock_calculator,
        was_tie_break_won_by_player(
            &mock_tie_break,
            One))
                 .Times ( 1 )
                 .WillOnce ( testing::Return ( true ) );

    // Act
    auto actual = sut.count_games ( One,
                                                   &mock_set );

    // Assert
    EXPECT_EQ("7", actual);
}