public class Character
{
    public int MinAttack;
    public int MaxAttack;
    public int ability;
    public int health;
    public int MaxHealth;
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

