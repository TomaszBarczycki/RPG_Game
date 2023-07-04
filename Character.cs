public class Character
{
    public int minattack;
    public int maxattack;
    public int ability;
    public int health;

    public int attack()
    {
        Random random = new Random();
        return random.Next(minattack, maxattack + 1);
    }
}
