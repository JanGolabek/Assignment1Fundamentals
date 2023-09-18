using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1.Warriors.EQ.Items;

namespace Assignment1.Warriors.EQ.Items.ItemTypes
{
    // WeaponItem object which inherits from the Item class and has one more
    // variable for the weapon damage

    public enum WeaponType
    {
        Staff,
        Wand,
        Bow,
        Dagger,
        Sword,
        Hatchet,
        Mace
    }
    public class WeaponItem : Item
    {
        public int WeaponDamage { get; set; }
        public WeaponType WeaponType { get; set; }
    }


}
