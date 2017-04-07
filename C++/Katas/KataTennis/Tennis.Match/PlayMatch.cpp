#include "stdafx.h"
#include <memory>
#include "IMatch.h"
#include "MatchFactory.h"
#include "ScoreBoard.h"
#include "MatchStatusToStringConverter.h"
#include <iostream>
#include "Logger.h"
#include "InputPlayerNames.h"
#include "PlayMatch.h"
#include "PlayerNameManager.h"
#include "GamesCounter.h"
#include "ITieBreakWinnerCalculator.h"
#include "TieBreakWinnerCalculator.h"
#include "CountPlayerGames.h"
#include "CurrentPlayerScoreCalculator.h"
#include "ScoresForPlayerCalculator.h"

namespace Tennis
{
    namespace Match
    {
        int PlayMatch::get_int_1_or_2 ()
        {
            int choice;
            do
            {
                std::cin >> choice;
            }
            while ( choice < 1 ||
                choice > 2 );

            return choice;
        }

        Logic::Player PlayMatch::ask_which_player_won_point ()
        {
            using namespace Tennis::Logic;

            std::cout << "Which player won a point (1 or 2)? ";

            int choice = get_int_1_or_2();

            return choice == 1 ? One : Two;
        }

        void PlayMatch::run () const
        {
            using namespace Tennis::Logic;

            InputPlayerNames input {};

            std::string player_name_one = input.get_player_name ( "1. Player name? " );
            std::string player_name_two = input.get_player_name ( "2. Player name? " );

            MatchFactory factory {};

            std::unique_ptr<IMatch> match = factory.create();

            std::unique_ptr<ILogger> logger = std::make_unique<Logger> ( std::cout );

            std::unique_ptr<IPlayerNameManager> player_name_manager = std::make_unique<PlayerNameManager> (
                                                                                                           logger.get(),
                                                                                                           player_name_one,
                                                                                                           player_name_two );

            std::unique_ptr<IGamesCounter> count_player_games_games_counter = std::make_unique<GamesCounter>();

            std::unique_ptr<ICurrentPlayerScoreCalculator> current_player_score_calculator = std::make_unique<CurrentPlayerScoreCalculator>();

            std::unique_ptr<ITieBreakWinnerCalculator> tie_break_winner_calculator = std::make_unique<TieBreakWinnerCalculator>();

            std::unique_ptr<ICountPlayerGames> count_player_games = std::make_unique<CountPlayerGames> (
                                                                                                        std::move ( count_player_games_games_counter ),
                                                                                                        std::move ( tie_break_winner_calculator ) );

            std::unique_ptr<IScoresForPlayerCalculator> scores_for_player_calculator = std::make_unique<ScoresForPlayerCalculator> (
                                                                                                                                    std::move ( current_player_score_calculator ),
                                                                                                                                    std::move ( count_player_games ) );

            std::unique_ptr<IGamesCounter> games_counter = std::make_unique<GamesCounter>();

            ScoreBoard score_board
            {
                std::move ( scores_for_player_calculator ),
                player_name_manager.get(),
                games_counter.get(),
                match->get_sets()
            };

            MatchStatus match_status;
            do
            {
                Player player = ask_which_player_won_point();

                match->won_point ( player );

                score_board.print ( std::cout );

                match_status = match->get_status();
            }
            while ( MatchStatus_PlayerOneWon != match_status &&
                MatchStatus_PlayerTwoWon != match_status );

            std::string status = MatchStatusToStringConverter {}.to_string ( match->get_status() );

            std::cout << status << "\n";
        }
    }
}
