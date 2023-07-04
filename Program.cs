using System;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information

int number;
do
{
    Console.WriteLine("Enter the number of players: ");
    number = int.Parse(Console.ReadLine());

    if (number <= 0)
    {
        Console.WriteLine("\nWrong number.");
    }

    else
    {
        Console.WriteLine("You entered a correct number: " + number);
        break;
    }

} while (true);
List<Player> list = new List<Player>();
for (int i = 1; i <= number; i++) {
    Console.WriteLine("Enter player's name: ");
    string name = Console.ReadLine();
    Console.WriteLine("\nEnter player's class\n1.Mage\n2.Warrior\n3.Archer: ");
    int choice = int.Parse(Console.ReadLine());

    Character character;
    switch (choice)
    {
        case 1: Console.WriteLine("You chose Mage!");
                character = new Mage();
                break;
        case 2: Console.WriteLine("You chose Warrior!");
                character = new Warrior();
                break;
        case 3: Console.WriteLine("You chose Archer!");
                character = new Archer();
                break;

    }
    Player player = new Player() { Name = name, Character = choice, ID = i };
    list.Add(player);
}

Console.WriteLine("\nList of players: ");
foreach(Player player in list)
{
    Console.WriteLine(player.ID + "." + player.Name + player.Character);
}


public class Player
{
    public string Name { get; set; }
    public int Character { get; set; }
    public int ID { get; set;}
}

public class Character
{
    public int attack;
    public int ability;
    public int health;

}
public class Mage: Character
{
    public Mage()
    {
        attack = 10;
        ability = 100;
        health = 700;
    }
}

public class Warrior: Character
{
    public Warrior()
    {
        int attack = 30;
        int ability = 60;
        int health = 1000;
    }
}

public class Archer: Character
{
    public Archer()
    {
        int attack = 20;
        int ability = 70;
        int health = 850;
    }
}




