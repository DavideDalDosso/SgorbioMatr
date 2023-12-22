using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

class Match
{
    private Unit[,] battlefield;
    private static Random random;
    private Player[] players;
    private Player currentTurnPlayer;
    private int currentTurn;

    public Match()
    {
        battlefield = new Unit[10, 10];
        players = new Player[2];

        if(random == null) random = new Random();
    }

    private void GameLoop()
    {
        foreach (Player player in players)
        {
            player.DrawCards(2);
        }

        Renderer.Render(this);
        Console.ReadKey(true);

        currentTurnPlayer = currentTurnPlayer.GetAdversary();
        currentTurn++;

        GameLoop();
    }

    public Unit[,] GetBattlefield()
    {
        return battlefield;
    }

    public static int GetRandomNumber(int bound)
    {
        return random.Next(bound);
    }

    public void Start()
    {
        currentTurnPlayer = GetPlayer(0);
        currentTurn = 1;
        GameLoop();
    }

    public void AddPlayer(Player player)
    {
        if (players[0]  == null)
        {
            players[0] = player;
        } else
        {
            players[1] = player;
        }
    }

    public Player GetPlayer(int index)
    {
        return players[index];
    }

    public void AddUnit(Unit unit, int row)
    {

    }
    public int GetTurn()
    {
        return currentTurn;
    }

    public Player GetCurrentPlayer()
    {
        return currentTurnPlayer;
    }
}
