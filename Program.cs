using System;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information

int number;
do
{
    Console.WriteLine("Podaj liczbę graczy: ");
    number = int.Parse(Console.ReadLine());

    if (number <= 0)
    {
        Console.WriteLine("\nBłędna liczba graczy.");
    }

    else
    {
        Console.WriteLine("Wprowadzono poprawną liczbę: " + number);
        break;
    }

} while (true);
List<Player> list = new List<Player>();
for (int i = 1; i <= number; i++) {
    Console.WriteLine("Wprowadź nazwę gracza: ");
    string name = Console.ReadLine();
    Console.WriteLine("\nWprowadź klasę gracza\n1.Mage\n2.Warrior\n3.Archer: ");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1: Console.WriteLine("You chose Mage!"); break;
        case 2: Console.WriteLine("You chose Warrior!"); break;
        case 3: Console.WriteLine("You chose Archer!"); break;

    }
    Player player = new Player() { Name = name, PlayerClass = choice, ID = i };
    list.Add(player);
}

Console.WriteLine("\nList of players: ");
foreach(Player player in list)
{
    Console.WriteLine(player.Name + " " + player.ID);
}


public class Player
{
    public string Name { get; set; }
    public int PlayerClass { get; set; }
    public int ID { get; set;}
}

public class Mage
{
int attack = 10;
int ability = 100;
int health = 700;
}

public class Warrior
{
    int attack = 30;
    int ability = 60;
    int health = 1000;
}

public class Archer
{
    int attack = 20;
    int ability = 70;
    int health = 850;
}




