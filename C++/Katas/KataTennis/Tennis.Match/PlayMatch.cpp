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

namespace Tennis
{
    namespace Match
    {
        int PlayMatch::get_int_1_or_2()
        {
            int choice;
            do
            {
                std::cin >> choice;
            } while (choice < 1 ||
                choice > 2);

            return choice;
        }

        Logic::Player PlayMatch::ask_which_player_won_point()
        {
            using namespace Tennis::Logic;

            std::cout << "Which player won a point (1 or 2)? ";

            int choice = get_int_1_or_2();

            return choice == 1 ? One : Two;
        }

        void PlayMatch::run() const
        {
            using namespace Tennis::Logic;

            InputPlayerNames input{};

            std::string player_name_one = input.get_player_name("1. Player name? ");
            std::string player_name_two = input.get_player_name("2. Player name? ");

            MatchFactory factory{};

            std::unique_ptr<IMatch> match = factory.create();

            std::unique_ptr<ILogger> logger = std::make_unique<Logger>(std::cout);

            std::unique_ptr<IPlayerNameManager> player_name_manager = std::make_unique<PlayerNameManager>(
                logger.get(),
                player_name_one,
                player_name_two);

            std::unique_ptr<IGamesCounter> games_counter = std::make_unique<GamesCounter>();

            ScoreBoard score_board
            {
                player_name_manager.get(),
                games_counter.get(),
                match->get_sets()
            };

            MatchStatus match_status;
            do
            {
                Player player = ask_which_player_won_point();

                match->won_point(player);

                score_board.print(std::cout);

                match_status = match->get_status();
            } while (MatchStatus_PlayerOneWon != match_status &&
                MatchStatus_PlayerTwoWon != match_status);

            std::string status = MatchStatusToStringConverter{}.to_string(match->get_status());

            std::cout << status << "\n";
        }
    }
}
