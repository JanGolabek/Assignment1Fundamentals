using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Warrior
{
    enum CharacterClass
    {
        None,
        Wizard,
        Archer,
        Swashbuckler,
        Barbarian
    }
    class Warrior
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public HeroAttribute Attributes { get; set; }
        public string Equipment { get; set; }
        public int Level { get; set; }

        public Warrior(CharacterClass characterClass = CharacterClass.None)
        {
            Class = characterClass;

            // Set attributes based on character class
            switch (characterClass)
            {
                case CharacterClass.Wizard:
                    Attributes = new HeroAttribute(1, 1, 8); 
                    break;
                case CharacterClass.Archer:
                    Attributes = new HeroAttribute(1, 7, 1); 
                    break;
                case CharacterClass.Swashbuckler:
                    Attributes = new HeroAttribute(2, 6, 1);
                    break;
                case CharacterClass.Barbarian:
                    Attributes = new HeroAttribute(5, 2, 1);
                    break;
                default:
                    Attributes = new HeroAttribute(0, 0, 0);
                    break;
            }
        }
    }

}
