using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assignment1.Warrior.EQ;
using Assignment1.Warrior;
using System.Xml.Linq;
using Assignment1.Warrior.EQ.ItemTypes;

internal class Equipment
{
    public ArmorItem HeadItem { get; set; }
    public ArmorItem BodyItem { get; set;}
    public ArmorItem LegsItem { get; set;}
    public WeaponItem WeaponItem { get; set;}

    public static WeaponItem SuperSword { get; } = new WeaponItem()
    {
        Name = "Super Sword",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Swashbuckler, CharacterClass.Barbarian },
        Slot = Slot.Weapon,
        RequiredLevel = 4,
        WeaponDamage = 20,
    };

    public static WeaponItem Sword { get; } = new WeaponItem()
    {
        Name = "Sword",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Swashbuckler, CharacterClass.Barbarian },
        Slot = Slot.Weapon,
        RequiredLevel = 1,
        WeaponDamage = 2,
    };

    public static ArmorItem Plate { get; } = new ArmorItem()
    {
        Name = "Plate",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Barbarian },
        Slot = Slot.Body,
        RequiredLevel = 1,
        ArmorAttribute = 2,
    };

    public static ArmorItem GoldPlate { get; } = new ArmorItem()
    {
        Name = "Gold plate",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Barbarian },
        Slot = Slot.Body,
        RequiredLevel = 5,
        ArmorAttribute = 6,
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



