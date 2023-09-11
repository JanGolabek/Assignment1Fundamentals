using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Warrior
{
    internal class HeroAttribute
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }
        public HeroAttribute Add(HeroAttribute other)
        {
            // Add the attributes of two instances and return a new instance
            return new HeroAttribute(
                Strength + other.Strength,
                Dexterity + other.Dexterity,
                Intelligence + other.Intelligence
            );
        }
        public void Increase(int strengthAmount, int dexterityAmount, int intelligenceAmount)
        {
            // Increase the attributes by the specified amounts
            Strength += strengthAmount;
            Dexterity += dexterityAmount;
            Intelligence += intelligenceAmount;
        }

        public override string ToString()
        {
            return $"Strength: {Strength}, Dexterity: {Dexterity}, Intelligence: {Intelligence}";
        }
    }

}
