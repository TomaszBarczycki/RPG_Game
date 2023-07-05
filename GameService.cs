using System;
using System.Collections.Generic;

public class GameService
{
    public void StartGame()
    {
        int number;
        bool UsedAbility = false;
        do
        {
            Console.WriteLine("Enter the number of players: ");
            number = int.Parse(Console.ReadLine());

            if (number <= 0)
            {
                Console.WriteLine("Wrong number.");
            }
            else
            {
                Console.WriteLine($"You entered a correct number: {number}");
                break;
            }

        } while (true);

        List<Player> list = new List<Player>();
        for (int i = 1; i <= number; i++)
        {
            Console.WriteLine("Enter player's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter player's class \n1.Mage\n2.Warrior\n3.Archer: ");
            int choice = int.Parse(Console.ReadLine());

            Character character;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("You chose Mage!");
                    character = new Mage();
                    break;
                case 2:
                    Console.WriteLine("You chose Warrior!");
                    character = new Warrior();
                    break;
                case 3:
                    Console.WriteLine("You chose Archer!");
                    character = new Archer();
                    break;
                default:
                    Console.WriteLine("Invalid choice, defaulting to Mage");
                    character = new Mage();
                    break;
            }

            Player player = new Player() { Name = name, Character = character, ID = i };
            list.Add(player);

            if (i % 2 == 0)
            {
                Console.WriteLine("The battle starts now!");

                Player player1 = list[i - 2];
                Player player2 = list[i - 1];

                Console.WriteLine($"{player1.Name} vs. {player2.Name}");

                while (player1.Character.health > 0 && player2.Character.health > 0)
                {
                    Console.WriteLine($"{player1.Name} attacks {player2.Name}");
                    player2.Character.health -= player1.Character.BasicAttack();
                    Console.WriteLine($"{player1.Name}'s HP: {player1.Character.health}   {player2.Name}'s HP: {player2.Character.health}\n");

                    if (player1.Character.health < player1.Character.MaxHealth * 0.5 && !UsedAbility)
                    {
                        Console.WriteLine($"{player1.Name} uses ability!");
                        player2.Character.health -= player1.Character.ability;
                        UsedAbility = true;
                    }

                    if (player2.Character.health < player2.Character.MaxHealth * 0.5 && !UsedAbility)
                    {
                        Console.WriteLine($"{player2.Name} uses ability!");
                        player1.Character.health -= player2.Character.ability;
                        UsedAbility = true;
                    }

                    if (player2.Character.health <= 0)
                    {
                        Console.WriteLine($"{player2.Name} has been defeated. {player1.Name} has won!");
                        break;
                    }

                    Console.WriteLine($"{player2.Name} attacks {player1.Name}");
                    player1.Character.health -= player2.Character.BasicAttack();

                    if (player1.Character.health <= 0)
                    {
                        Console.WriteLine($"{player1.Name} has been defeated. {player2.Name} has won!\n");
                        break;
                    }
                }
            }
        }

        List<Player> winners = new List<Player>(list);

        while (winners.Count > 1)
        {
            List<Player> NextRoundWinners = new List<Player>();

            for (int i = 1; i <= winners.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("The battle starts now!");

                    Player player1 = winners[i - 2];
                    Player player2 = winners[i - 1];

                    Console.WriteLine($"{player1.Name} vs. {player2.Name}");

                    while (player1.Character.health > 0 && player2.Character.health > 0)
                    {
                        Console.WriteLine($"{player1.Name} attacks {player2.Name}");
                        player2.Character.health -= player1.Character.BasicAttack();
                        Console.WriteLine($"{player1.Name}'s HP: {player1.Character.health}   {player2.Name}'s HP: {player2.Character.health}\n");

                        if (player1.Character.health < player1.Character.MaxHealth * 0.5 && !UsedAbility)
                        {
                            Console.WriteLine($"{player1.Name} uses ability!");
                            player2.Character.health -= player1.Character.ability;
                            UsedAbility = true;
                        }

                        if (player2.Character.health < player2.Character.MaxHealth * 0.5 && !UsedAbility)
                        {
                            Console.WriteLine($"{player2.Name} uses ability!");
                            player1.Character.health -= player2.Character.ability;
                            UsedAbility = true;
                        }

                        if (player2.Character.health <= 0)
                        {
                            Console.WriteLine($"{player2.Name} has been defeated. {player1.Name} has won!");
                            break;
                        }

                        Console.WriteLine($"{player2.Name} attacks {player1.Name}");
                        player1.Character.health -= player2.Character.BasicAttack();

                        if (player1.Character.health <= 0)
                        {
                            Console.WriteLine($"{player1.Name} has been defeated. {player2.Name} has won!");
                            break;
                        }
                    }

                    Player roundWinner = player1.Character.health > 0 ? player1 : player2;
                    NextRoundWinners.Add(roundWinner);
                }
            }

            winners = NextRoundWinners;
        }

        Console.WriteLine($"The winner of the whole game is {winners[0].Name}!");
    }
}

