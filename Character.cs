public class Character
{
    public int MinAttack;
    public int MaxAttack;
    public int ability;
    public int health;
    Random random = new Random();

    public int BasicAttack()
    {
        return random.Next(MinAttack, MaxAttack + 1);
    }

    public int AbilityAttack()
    {
        return ability;
    }

}

