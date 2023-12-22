using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Player
{
    private List<Card> deck = new List<Card>();
    private List<Card> hand = new List<Card>();
    private Player adversary;
    private List<Unit> units = new List<Unit>();

    public Card[] GetHandCards()
    {
        return hand.ToArray();
    }
    public Card[] GetDeckCards()
    {
        return deck.ToArray();
    }
    public void UseCard(Card card)
    {
        deck.Add(card);
        hand.Remove(card);
    }
    public void AddDeckCard(Card card)
    {
        card.SetOwner(this);
        deck.Add(card);
    }

    public void AddHandCard(Card card)
    {
        card.SetOwner(this);
        hand.Add(card);
    }

    public void RemoveCard(Card card)
    {
        if(deck.Contains(card))
        {
            deck.Remove(card);
        }
        if(hand.Contains(card))
        {
            hand.Remove(card);
        }
    }

    public void DrawCards(int cards)
    {
        for(int i = 0; i < cards; i++)
        {
            Card[] deck = GetDeckCards();
            if( deck.Length <= 0 ) return;

            int index = Match.GetRandomNumber(deck.Length);

            DrawCard(deck[index]);
        }
    }

    public void DrawCard(Card card)
    {
        deck.Remove(card);
        hand.Add(card);
    }

    public void SetAdversary(Player adversary)
    {
        this.adversary = adversary;
    }

    public Player GetAdversary()
    {
        return adversary;
    }

    public Unit[] GetUnits()
    {
        return units.ToArray();
    }

    public void AddUnit(Unit unit)
    {
        units.Add(unit);
    }

    public void removeUnit(Unit unit)
    {
        units.Remove(unit);
    }

}
