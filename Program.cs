using System;
using System.Collections.Generic;


namespace TicTacToeGame
{
    class Program
    {
        //       |       |
        //   1   |   2   |   3
        //_______|_______|_______   
        //       |       |
        //   4   |   5   |   6 
        //_______|_______|_______
        //       |       |
        //   7   |   8   |   9
        //       |       |

        //Player 1: Choose your field!
        //Incorrect input! Please use another field!
        //Player 2 has won!
        //Press any Key to Reset the Game








        static void Main(string[] args)
        {
            int player1Score = 0;
            int player2Score = 0;
            int gameRound = 0;
            int playerNumTurn = 1;
            int playerNum;

            //Start the game and continue until user enters 'q'. Keep track of player score
            while (true)
            {
                if (gameRound == 0)
                {
                    Console.WriteLine("Welcome to TIC TAC TOE GAME ");
                }
                else
                {
                    Console.WriteLine("GAME ROUND: {0}", gameRound);
                    Console.WriteLine("Player 1 score is {0}", player1Score);
                    Console.WriteLine("Player 2 score is {0}", player2Score);
                }


                DisplayTicTacTocArray();

                //At the end of the game rotate which player starts first
                playerNum = UpdadeStartPlayerTurn(playerNumTurn);
                //if (playerNumTurn == 1)
                //{
                //    playerNum = 1;
                //}
                //else
                //{
                //    playerNum = 2;
                //}


                //While loop for individual game
                while (true)
                {
                    bool win = false;
                    int validPlayerInput;

                    playerNum = UpdadeStartPlayerTurn(playerNum);

                    validPlayerInput = GetUserInput(playerNum);

                    UpdateArray(validPlayerInput, playerNum);

                    Console.Clear();
                    DisplayTicTacTocArray();
                    win = CheckIfWinner(playerNum);
                    if (win)
                    {
                        Console.WriteLine("CONGRATULATIONS\nPlayer{0} has won! ", playerNum);
                        //increase winner's score
                        if (playerNum == 1)
                        {
                            player1Score++;
                        }
                        else
                        {
                            player2Score++;
                        }
                        gameRound++;
                        break;
                    }

                    //if all fields are field and no match, there is no winner for that round
                    if (userInputTracker.Count == 9)
                    {
                        Console.WriteLine("No winner");
                        break;
                    }
                }

                Console.WriteLine("\nPress any key to play again. \nPress 'q' to quit\n");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.Clear();


                playerNumTurn = UpdadeStartPlayerTurn(playerNumTurn);

                //Remove X and O from Display
                ResetTicTacTokDisplay();

                //empty user Input Tracker list
                userInputTracker.Clear();


            }
        }

        static string[,] ticTacToc2DArray =
        {
            {"1","2","3"},
            {"4", "5", "6"},
            {"7", "8", "9"}
        };
        static int GetUserInput(int playerNum)
        {
            string playerInput;
            Console.WriteLine("Player {0}: Choose your field! ", playerNum);
            playerInput = Console.ReadLine();
            int validPlayerInput = CheckIfUserInputValid(playerInput);
            return validPlayerInput;
        }

        static int UpdadeStartPlayerTurn(int startPlayerTurn)
        {
            if (startPlayerTurn == 2)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }


        static void ResetTicTacTokDisplay()
        {
            int count = 1;
            for (int i = 0; i < ticTacToc2DArray.GetLength(0); i++)
            {
                for (int j = 0; j < ticTacToc2DArray.GetLength(1); j++)
                {
                    ticTacToc2DArray[i, j] = count.ToString();
                    count++;
                }

            }
        }

        static List<int> userInputTracker = new List<int>();
        //update the 2Dimensional array with the user's input
        static void UpdateArray(int playerInput, int playerNum)
        {
            foreach (int i in userInputTracker)
            {
                while (i == playerInput)
                {
                    Console.WriteLine("This field has already been chosen. Please try again.");
                    playerInput = GetUserInput(playerNum);
                }
            }


            //Get X for player 1 and O for player 2
            string letter = GetPlayerSymbol(playerNum);


            switch (playerInput)
            {
                case 1:
                    ticTacToc2DArray[0, 0] = letter;
                    userInputTracker.Add(1);
                    break;
                case 2:
                    ticTacToc2DArray[0, 1] = letter;
                    userInputTracker.Add(2);
                    break;
                case 3:
                    ticTacToc2DArray[0, 2] = letter;
                    userInputTracker.Add(3);
                    break;
                case 4:
                    ticTacToc2DArray[1, 0] = letter;
                    userInputTracker.Add(4);
                    break;
                case 5:
                    ticTacToc2DArray[1, 1] = letter;
                    userInputTracker.Add(5);
                    break;
                case 6:
                    ticTacToc2DArray[1, 2] = letter;
                    userInputTracker.Add(6);
                    break;
                case 7:
                    ticTacToc2DArray[2, 0] = letter;
                    userInputTracker.Add(7);
                    break;
                case 8:
                    ticTacToc2DArray[2, 1] = letter;
                    userInputTracker.Add(8);
                    break;
                case 9:
                    ticTacToc2DArray[2, 2] = letter;
                    userInputTracker.Add(9);
                    break;
            }
        }

        static bool CheckIfWinner(int playerNum)
        {
            string letter = GetPlayerSymbol(playerNum);
            bool winner = false;

            if (ticTacToc2DArray[0, 0] == letter && ticTacToc2DArray[0, 1] == letter && ticTacToc2DArray[0, 2] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[1, 0] == letter && ticTacToc2DArray[1, 1] == letter && ticTacToc2DArray[1, 2] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[2, 0] == letter && ticTacToc2DArray[2, 1] == letter && ticTacToc2DArray[2, 2] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[0, 0] == letter && ticTacToc2DArray[1, 0] == letter && ticTacToc2DArray[2, 0] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[0, 1] == letter && ticTacToc2DArray[1, 1] == letter && ticTacToc2DArray[2, 1] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[0, 2] == letter && ticTacToc2DArray[1, 2] == letter && ticTacToc2DArray[2, 2] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[0, 0] == letter && ticTacToc2DArray[1, 1] == letter && ticTacToc2DArray[2, 2] == letter)
            {
                winner = true;
            }
            else if (ticTacToc2DArray[2, 0] == letter && ticTacToc2DArray[1, 1] == letter && ticTacToc2DArray[0, 2] == letter)
            {
                winner = true;
            }

            return winner;

        }

        static string GetPlayerSymbol(int playerNum)
        {
            string symbol;
            if (playerNum == 1)
            {
                symbol = "X";
            }
            else
            {
                symbol = "O";
            }
            return symbol;

        }

        static int CheckIfUserInputValid(string userInput)
        {
            int result;

            while (!Int32.TryParse(userInput, out result) || result <= 0 || result >= 10)
            {
                Console.Write("Invalid input. Choose your field! ");
                userInput = Console.ReadLine();
            }


            return result;
        }


        //Print the pipes for the layout  |
        static void PrintArrayPipes(string symbol)
        {
            for (int j = 0; j < ticTacToc2DArray.GetLength(1); j++)
            {
                Console.Write("       ");

                if (j < ticTacToc2DArray.GetLength(1) - 1)
                {
                    Console.Write("|");
                }
            }
            Console.Write("\n");
        }

        //Print underscores for the layout ______
        static void PrintArrayLine(int i, string arrLine)
        {
            if (i != 0 && i < ticTacToc2DArray.GetLength(0))
            {
                Console.WriteLine("_______________________\n");
            }
        }




        static void DisplayTicTacTocArray()
        {
            //check rows of 2D array
            for (int i = 0; i < ticTacToc2DArray.GetLength(0); i++)
            {
                PrintArrayLine(i, "_");
                PrintArrayPipes("|");

                //check columns of 2D array

                for (int j = 0; j < ticTacToc2DArray.GetLength(1); j++)
                {
                    if (ticTacToc2DArray[i, j] == "X")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (ticTacToc2DArray[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    Console.Write("   {0}   ", ticTacToc2DArray[i, j]);

                    Console.ForegroundColor = ConsoleColor.White;
                    if (j < ticTacToc2DArray.GetLength(1) - 1)
                    {
                        Console.Write("|");
                    }
                }
                Console.Write("\n");
                PrintArrayPipes("|");
            }
        }


    }
}


