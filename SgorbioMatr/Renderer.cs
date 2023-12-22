
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
class Renderer
{
    public static void Render(Match match)
    {
        Console.Clear();
        //HORIZONTAL LINES
        Console.Write(new String('#', Console.BufferWidth));
        Console.SetCursorPosition(0, 6);
        Console.Write(new String('#', Console.BufferWidth));
        Console.SetCursorPosition(0, 48);
        Console.Write(new String('#', Console.BufferWidth));
        Console.SetCursorPosition(0, 59);
        Console.Write(new String('#', Console.BufferWidth));

        //VERTICAL LINES
        for(int i = 0; i < 60; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(43, i);
            Console.Write("#");
            Console.SetCursorPosition(195, i);
            Console.Write("#");
            Console.SetCursorPosition(238, i);
            Console.Write("##");
        }

        RenderBattlefield(match, 44, 7);

        Player player1 = match.GetPlayer(0);
        Player player2 = match.GetPlayer(1);

        RenderHand(match, 1, 7, player1, 0);
        RenderHand(match, 196, 7, player2, 0);

        Console.SetCursorPosition(2, 2);
        Console.Write("Player1");

        if(match.GetCurrentPlayer() ==  player1)
        {
            Console.Write(" @");
        }

        Console.SetCursorPosition(197, 2);
        Console.Write("Player2");

        if (match.GetCurrentPlayer() == player2)
        {
            Console.Write(" @");
        }

        Console.SetCursorPosition(113, 2);
        Console.Write("Turn " + match.GetTurn());

    }

    private static void RenderBattlefield(Match match, int xOff, int yOff)
    {
        Unit[,] battlefield = match.GetBattlefield();

        const int cellWidth = 15;
        const int cellHeight = 4;

        int gridWidth = battlefield.GetLength(0);
        int gridHeight = battlefield.GetLength(1);

        for (int y = 0; y < battlefield.GetLength(1); y++)
        {
            Console.SetCursorPosition(xOff, yOff + y * cellHeight);
            Console.Write(new String('@', gridWidth * cellWidth));
        }

        for (int x = 0; x < battlefield.GetLength(0); x++)
        {
            for (int i = 0; i < gridHeight * cellHeight; i++)
            {
                Console.SetCursorPosition(xOff + x * cellWidth, yOff + i);
                Console.Write("@");
            }

            for (int y = 0; y < battlefield.GetLength(1); y++)
            {
                Unit? unit = battlefield[x, y];

                if (unit != null)
                {
                    Console.SetCursorPosition(xOff + x * cellWidth + 2, yOff + y * cellHeight + 2);
                    Console.Write(unit.GetName());
                }
            }
        }
        Console.SetCursorPosition(xOff, yOff + cellHeight * gridHeight);
        Console.Write(new String('@', cellWidth * gridWidth + 1));
        for (int i = 0; i < cellHeight * gridHeight + 1; i++)
        {
            Console.SetCursorPosition(xOff + cellWidth * gridWidth, yOff + i);
            Console.Write("@");
        }
    }

    private static void RenderHand(Match match, int xOff, int yOff, Player player, int index)
    {
        const int cellWidth = 41;
        const int cellHeight = 10;

        Card[] hand = player.GetHandCards();

        for (int i = 0; i < cellHeight * 4 + 1; i++)
        {
            Console.SetCursorPosition(xOff, yOff + i);
            Console.Write("@");
        }

        for (int i = 0; i < 4; i++)
        {
            Console.SetCursorPosition(xOff, yOff + cellHeight * i);
            Console.Write(new String('@', cellWidth + 1));



            Card? card;

            if(i < hand.Length)
            {
                card = hand[i];
            } else
            {
                card = null;
            }

            if (card != null)
            {
                Console.SetCursorPosition(xOff + 5, yOff + i * cellHeight + 2);
                Console.Write(card.GetName());
            }

        }
        Console.SetCursorPosition(xOff, yOff + cellHeight * 4);
        Console.Write(new String('@', cellWidth + 1));
        for (int i = 0; i < cellHeight * 4 + 1; i++)
        {
            Console.SetCursorPosition(xOff + cellWidth, yOff + i);
            Console.Write("@");
        }
    }
}
