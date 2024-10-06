
using static Players;

class Board
{
    private String[,] visualBoard;
    private Players player1;
    private Players player2;
    public Board(String player1Sign, String player2Sign)
    {   

        // used to visually display the board for the user.
        visualBoard = new string[3, 3] {{"_", "_", "_"},
                                        {"_", "_", "_"},
                                        {"_", "_", "_"}};
        
        player1 = new Players(1, player1Sign);
        player2 = new Players(2, player2Sign);
        askPlayerName(player1);
        askPlayerName(player2);
    } 

    private bool CheckBoard(String playerSign)
    {   

        for (int i = 0; i < 3; i++)
        {
            if (visualBoard[i, 0] == playerSign && visualBoard[i, 1] == playerSign && visualBoard[i, 2] == playerSign)
            {
                return true;
            }
            if (visualBoard[0, i] == playerSign && visualBoard[1, i] == playerSign && visualBoard[2, i] == playerSign)
            {
                return true;
            }
        }

        if (visualBoard[0, 0] == playerSign && visualBoard[1, 1] == playerSign && visualBoard[2, 2] == playerSign)
        {        
            return true;
        }
        if (visualBoard[0, 2] == playerSign && visualBoard[1, 1] == playerSign && visualBoard[2, 0] == playerSign)
        {   
            return true;
        }
        
        return false;
    }  

    private void DisplayBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(visualBoard[i, j] + " ");
            }
            Console.WriteLine();
        }
    }


    private void askPlayerName(Players player)
    {
        Console.WriteLine("{0} what is your name.", player.PlayerName);
        String? name = Console.ReadLine();
        player.PlayerName = name!;
    }

    private void placePlayerSign(Players players)
    {   
        bool availablePlace = true;
        while (availablePlace)
        {
            int row = getCorrectInput(players.PlayerName, "row");
            int column = getCorrectInput(players.PlayerName, "column");
            
            if (visualBoard[row, column] == "_")
            {
                visualBoard[row, column] = players.PlayerSign;
                availablePlace = false;
            }
            else
            {
                Console.WriteLine("Position is taken, try again!");
            }
        }
    }

    private int getCorrectInput(String playerName, String direction)
    {
        int value;
        while (true)
        {
            Console.WriteLine("{0} enter the desired {1} (first {1} begins at the number 0)", playerName, direction);
            String? givenNum = Console.ReadLine();
            Console.WriteLine();
            int result;
            bool isInteger = int.TryParse(givenNum, out result);
            if (isInteger && result < 3  && result >= 0)
            {
                value = result;
                return value;
            }
            else
            {
                Console.WriteLine("Incorrect input, try again");
            }
        }

    }

    private bool tieGame()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                
                if (visualBoard[i, j] == "_")
                {
                    return false;
                }
            }
        }
        return true;
    }

    public void StartGame()
    {   
        Console.WriteLine("{0} is X and {1} is O", player1.PlayerName, player2.PlayerName);
        Console.WriteLine("Beginning game........");
        DisplayBoard();

        while (true)
        {   
            placePlayerSign(player1);
            DisplayBoard();
            if (CheckBoard(player1.PlayerSign))
            {
                Console.WriteLine("{0} has won!", player1.PlayerName);
                break;
            }

            if (tieGame())
            {
                Console.WriteLine("game is tied!");
                break;
            }

            placePlayerSign(player2);
            DisplayBoard();
            if (CheckBoard(player2.PlayerSign))
            {
                Console.WriteLine("{0} has won!", player2.PlayerName);
                break;
            }

            if (tieGame())
            {
                Console.WriteLine("game is tied!");
                break;
            }
        }
    }
}