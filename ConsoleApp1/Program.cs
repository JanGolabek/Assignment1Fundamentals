using Assignment1.Warrior;
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
            PrintOutWarrior(createdWarrior);
        }
        public static void PrintOutWarrior(Warrior warrior)
        {
            Console.WriteLine("Name: " + warrior.Name +
                "\nClass: " + warrior.Class +
                "\nLevel: " + warrior.Level +
                "\nLevel Attributes: " + warrior.Attributes + 
                "\nEquipment: " + warrior.Equipment + 
                "\nDamage: " + warrior.Damage
                );
        }
    }
}