using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Warrior.EQ.Items;

namespace Assignment1.Warrior.EQ.Items.ItemTypes
{

    // ArmorItem object which inherits from the Item class and has one more
    // variable for the armor attribute
    internal class ArmorItem : Item
    {
        public HeroAttribute ArmorAttribute { get; set; }
    }
}
