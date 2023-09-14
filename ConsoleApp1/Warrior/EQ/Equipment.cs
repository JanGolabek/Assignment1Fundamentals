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
    public Item HeadItem { get; set; }
    public Item BodyItem { get; set;}
    public Item LegsItem { get; set;}
    public Item WeaponItem { get; set;}

    public static Item Helmet = new Item()
    {
        Name = "Helmet",
        Slot = Slot.Head,
        RequiredLevel = 2,
        ItemAttribute = 3,
    };

    public static Item SuperHelmet { get; } = new Item()
    {
        Name = "Super helmet",
        Slot = Slot.Head,
        RequiredLevel = 5,
        ItemAttribute = 5,
    };

    public static Item SuperSword { get; } = new Item()
    {
        Name = "Super Sword",
        Slot = Slot.Weapon,
        RequiredLevel = 4,
        ItemAttribute = 20,
    };

    public static Item Sword { get; } = new Item()
    {
        Name = "Sword",
        Slot = Slot.Weapon,
        RequiredLevel = 1,
        ItemAttribute = 2,
    };

    public static Item Boots { get; } = new Item()
    {
        Name = "Boots",
        Slot = Slot.Legs,
        RequiredLevel = 4,
        ItemAttribute = 20,
    };
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Equipped Items:");
        if (HeadItem != null)
            sb.AppendLine($"Head Armor: {HeadItem.Name}");
        if (BodyItem != null)
            sb.AppendLine($"Body Armor: {BodyItem.Name}");
        if (LegsItem != null)
            sb.AppendLine($"Legs Armor: {LegsItem.Name}");
        if (WeaponItem != null)
            sb.AppendLine($"Weapon: {WeaponItem.Name}");

        return sb.ToString();
    }

}



