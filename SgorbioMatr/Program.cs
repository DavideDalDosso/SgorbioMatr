public class Program
{
    public static void Main(string[] args)
    {
        Console.SetBufferSize(240, 60);
        Console.SetWindowSize(Console.BufferWidth, Console.BufferHeight);

        Match match = new Match();

        Player player1 = new Player();
        Player player2 = new Player();
        player1.SetAdversary(player2);
        player2.SetAdversary(player1);
        match.AddPlayer(player1);
        match.AddPlayer(player2);
        
        Card swordguy = new Card();
        swordguy.SetOnUse(() =>
        {
            
        });
        swordguy.SetName("Swordguy");
        Card archerguy = new Card();
        archerguy.SetOnUse(() =>
        {

        });
        archerguy.SetName("Archerguy");

        player1.AddDeckCard(swordguy.Clone());
        player1.AddDeckCard(swordguy.Clone());
        player1.AddDeckCard(archerguy.Clone());
        player1.AddDeckCard(archerguy.Clone());

        player2.AddDeckCard(swordguy.Clone());
        player2.AddDeckCard(swordguy.Clone());
        player2.AddDeckCard(swordguy.Clone());
        player2.AddDeckCard(archerguy.Clone());

        match.Start();
    }
}