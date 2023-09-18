using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Warriors.EQ.Items;

namespace Assignment1.Warriors.EQ.Items.ItemTypes
{

    // ArmorItem object which inherits from the Item class and has one more
    // variable for the armor attribute
    public enum ArmorType
    {
        Cloth,
        Leather,
        Mail,
        Plate
    }
    public class ArmorItem : Item
    {
        public HeroAttribute ArmorAttribute { get; set; }
        public ArmorType ArmorType { get; set; }
    }
}
