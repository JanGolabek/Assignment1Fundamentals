using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Warrior.EQ.ItemTypes
{
    internal class ArmorItem
    {
        public string Name { get; set; }
        public List<CharacterClass> WarriorClass { get; set; }
        public Slot Slot { get; set; }
        public int RequiredLevel { get; set; }
        public int ArmorAttribute { get; set; }
    }
}
