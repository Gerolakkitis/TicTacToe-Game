using System;
using System.Collections.Generic;


namespace TicTacToeGame
{
    class Program
    {

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

                //Rotate which player starts first
                playerNum = UpdadeStartPlayerTurn(playerNumTurn);

                //While loop for individual game
                while (true)
                {
                    bool win = false;
                    int validPlayerInput;

                    playerNum = UpdadeStartPlayerTurn(playerNum); //rotate turns of player
                    validPlayerInput = GetUserInput(playerNum); //check if input is valid
                    UpdateArray(validPlayerInput, playerNum); //update display
                    Console.Clear(); 
                    DisplayTicTacTocArray(); //show updated array

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
                        Console.WriteLine("No winner. Repeating this round!");
                        break;
                    }
                }

                Console.WriteLine("\nPress any key to play again. \nPress 'q' to quit\n");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                {
                    break;
                }
                Console.Clear();

                //update playerNumTurn to update the loop at which player starts first
                playerNumTurn = UpdadeStartPlayerTurn(playerNumTurn);

                //Remove X and O from Display
                ResetTicTacTokDisplay();

                //empty user Input Tracker list
                userInputTracker.Clear();


            }
        }

        //initialize 2D array
        static string[,] ticTacToc2DArray =
        {
            {"1","2","3"},
            {"4", "5", "6"},
            {"7", "8", "9"}
        };


        //Get user input and call method to verify valid input
        static int GetUserInput(int playerNum)
        {
            string playerInput;
            Console.WriteLine("Player {0}: Choose your field! ", playerNum);
            playerInput = Console.ReadLine();
            int validPlayerInput = CheckIfUserInputValid(playerInput);
            return validPlayerInput;
        }


        //method that helps rotate player on each game and each round
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

        //reset display at the end of the game
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

        //make global list to keep track of user input
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
                    ticTacToc2DArray[0, 0] = letter; //Assign X or O 
                    userInputTracker.Add(1); //add to a list if user chose 1 to avoid repeats. Checks in other method if a repeat.
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


        //Check all possible ways a player is a winner
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

        //Based on player turn change symbol to O or X to match player
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


        //Verify user input is digit, between 0 and 10
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



        //Display the game and add colors
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
                        Console.ForegroundColor = ConsoleColor.Red; //X is color Red
                    }
                    else if (ticTacToc2DArray[i, j] == "O")
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; //O is color Blue
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


