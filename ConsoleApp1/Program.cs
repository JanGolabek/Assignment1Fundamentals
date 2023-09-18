using Assignment1.Warriors;
using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name of the warrior: ");
            string warriorName = Console.ReadLine();
            Warrior warrior = new Warrior();
            Warrior createdWarrior = warrior.CreateWarrior(warriorName);

            while (true)
            {
                PrintOutWarrior(createdWarrior);
                Console.WriteLine("Would you like to level up?");
                string levelUpAnswer = Console.ReadLine();

                if (levelUpAnswer == "y")
                {
                    createdWarrior.LevelUp();
                }
                else if (levelUpAnswer == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine(
                        "Invalid input. Please enter 'y' to level up or 'exit' to quit."
                    );
                }
            }

            Console.WriteLine("Exiting the program.");
        }

        public static void PrintOutWarrior(Warrior warrior)
        {
            Console.WriteLine("Name: " + warrior.Name +
                "\nClass: " + warrior.Class +
                "\nLevel: " + warrior.Level +
                "\nLevel Attributes: " + warrior.Attributes + 
                "\n" +  warrior.Equipment.ToString() + 
                "\nDamage: " + warrior.Damage
                );
        }
    }
}