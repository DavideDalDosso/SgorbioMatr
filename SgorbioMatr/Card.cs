using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Card
{
    private Action onUse;
    private Player owner;
    private string name;

    public void Use()
    {
        owner.UseCard(this);
    }

    public void SetOnUse(Action onUse)
    {
        this.onUse = onUse;
    }

    public void SetOwner(Player owner)
    {
        this.owner = owner;
    }
    public Player GetOwner()
    {
        return owner;
    }

    public void SetName(string name)
    {
        this.name = name;
    }
    public string GetName()
    {
        return this.name;
    }
    public Card Clone()
    {
        Card clone = new Card();
        clone.name = this.name;
        clone.SetOnUse(this.onUse);

        return clone;
    }
}
