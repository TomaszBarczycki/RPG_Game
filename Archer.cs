using System;

public class Archer : Character
{
    public Archer()
    {
        Random rand = new Random();
        minattack = 1;
        maxattack = 25;
        ability = 70;
        health = 850;
    }
}
