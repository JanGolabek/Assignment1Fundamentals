using Assignment1.Warrior;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Warrior warrior1 = new Warrior()
            //{
            //    Name = "",
            //    Class = CharacterClass.Barbarian,
            //    Level = 1,
            //    Equipment = "Dagger"
            //};

            Console.WriteLine("Enter the name of the warrior: ");
            string warriorName = Console.ReadLine();
            Console.WriteLine($"Welcome {warriorName}. Which class do you want your" +
                $"character to be?" + "\n Choose from: Wizard, Archer, Swashbuckler, Barbarian");
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
                            attributes = new HeroAttribute(5, 3, 7); // Example attribute values for a wizard
                            break;
                        case CharacterClass.Barbarian:
                            attributes = new HeroAttribute(8, 4, 2); // Example attribute values for a barbarian
                            break;
                        default:
                            attributes = new HeroAttribute(0, 0, 0); // Default attributes
                            break;
                    }

                    // Create a new warrior with the provided name, class, attributes, and other properties
                    Warrior warrior = new Warrior()
                    {
                        Name = warriorName,
                        Class = warriorClass,
                        Attributes = attributes, // Set the attributes based on the class
                        Equipment = "Dagger",
                        Level = 1
                    };

                    // Now you have a new warrior object ready for use
                    PrintOutWarrior(warrior);
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
                "\nEquipment: " + warrior.Equipment);
        }
        public static void LevelUp(Warrior warrior)
        {
            warrior.Level++;
        }
    }
}