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
            Console.WriteLine($"Welcome {warriorName}. Which class do you want your" +
                $" character to be?" + "\n Choose from: Wizard, Archer, Swashbuckler, Barbarian");
            string className = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(warriorName))
            {
                Console.WriteLine("Invalid warrior name");
            }
            else
            {
                if (Enum.TryParse<CharacterClass>(className, out CharacterClass warriorClass))
                {
                    // Initialize the warrior's attributes based on the character class
                    HeroAttribute attributes;
                    switch (warriorClass)
                    {
                        case CharacterClass.Wizard:
                            attributes = new HeroAttribute(1, 1, 8);
                            break;
                        case CharacterClass.Archer:
                            attributes = new HeroAttribute(1, 7, 1);
                            break;
                        case CharacterClass.Swashbuckler:
                            attributes = new HeroAttribute(2, 6, 1);
                            break;
                        case CharacterClass.Barbarian:
                            attributes = new HeroAttribute(5, 2, 1);
                            break;
                        default:
                            attributes = new HeroAttribute(0, 0, 0);
                            break;
                    }

                    // Create a new warrior with the provided name, class, attributes, and other properties
                    Warrior warrior = new Warrior()
                    {
                        Name = warriorName,
                        Class = warriorClass,
                        Attributes = attributes, // Set the attributes based on the class
                        Level = 1,
                        Damage = 1,
                    };

                    // Now you have a new warrior object ready for use
                    PrintOutWarrior(warrior);
                    Console.WriteLine("Would you like to level up? (Y/N)");
                    string levelUpResponse = Console.ReadLine();

                    if (levelUpResponse != null && (levelUpResponse.ToLower() == "y"))
                    {
                        warrior.LevelUp();
                        Console.WriteLine("Warrior leveled up!");
                        PrintOutWarrior(warrior); // Print the updated warrior details
                    }
                }
                else
                {
                    Console.WriteLine("Invalid class");
                }
            }
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