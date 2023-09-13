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

    public static Item Helmet = new Item()
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

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Equipped Items:");
        if (HeadArmor != null)
            sb.AppendLine($"Head Armor: {HeadArmor.Name}");
        if (BodyArmor != null)
            sb.AppendLine($"Body Armor: {BodyArmor.Name}");
        if (LegsArmor != null)
            sb.AppendLine($"Legs Armor: {LegsArmor.Name}");
        if (Weapon != null)
            sb.AppendLine($"Weapon: {Weapon.Name}");

        return sb.ToString();
    }

}



