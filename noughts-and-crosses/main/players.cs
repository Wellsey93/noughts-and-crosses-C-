

class Players
{      
    private String playerName;
    private int playerNumber;
    private String playerSign;
    
    public Players(int givenPlayerNumber, String givenPlayerSign)
    {
        playerNumber = givenPlayerNumber;
        playerName = "player " + givenPlayerNumber;
        playerSign = givenPlayerSign;
    }   


    public String PlayerSign
    {
        get { return playerSign; }
    }

    public int PlayerNumber
    {
        get { return playerNumber; }
    }
    public String PlayerName
    {
        get { return playerName; }

        set {
            if (value.Length > 20 || string.IsNullOrWhiteSpace(value))
            {   
                Console.WriteLine("Name is not valid, switching to default name instead");
                playerName = "player " + playerNumber;
            }
            else
            {
                playerName = value;
            }
        }
    }
}