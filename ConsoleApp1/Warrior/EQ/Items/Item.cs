using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Warrior.EQ.Items
{

    // Common base class Item
    internal class Item
    {
        public string Name { get; set; }
        public List<CharacterClass> WarriorClass { get; set; }
        public Slot Slot { get; set; }
        public int RequiredLevel { get; set; }
    }
}
