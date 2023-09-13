using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assignment1.Warrior.EQ;
using Assignment1.Warrior;
using System.Xml.Linq;

internal class Equipment
{
    public Item HeadArmor { get; set; }
    public Item BodyArmor { get; set;}
    public Item LegsArmor { get; set;}
    public Item Weapon { get; set;}

    Item helmet = new Item()
    {
        Name = "Helmet",
        Slot = Slot.Head,
        RequiredLevel = 2,
        ItemAttribute = 3,
    };

    public static Item Sword { get; } = new Item()
    {
        Name = "Sword",
        Slot = Slot.Weapon,
        RequiredLevel = 1,
        ItemAttribute = 2,
    };

}



