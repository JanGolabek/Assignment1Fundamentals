using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assignment1.Warrior.EQ;
using Assignment1.Warrior;
using System.Xml.Linq;
using Assignment1.Warrior.EQ.Items.ItemTypes;
using Assignment1.Warrior.EQ.Items;

// Here's why the change from Armor and WeaponItem to Item makes sense:

// Polymorphism: When ArmorItem and WeaponItem both inherit from Item,
// they become polymorphic, which means we can use them interchangeably
// as instances of the base class Item. This allows us to work with
// armor and weapons in a more general way without needing to differentiate
// between the two types.

// Simplified Code: By using a common base class, the code becomes simpler
// and more generic. Instead of having separate properties for HeadItem,
// BodyItem, LegsItem, and WeaponItem, we can have a single property of
// type Item for each slot in the Equipment class. This reduces redundancy
// and makes the code easier to maintain.

// Flexibility: If we decide to add more types of items in the future, we
// can easily extend your Equipment class without modifying its structure. We
// can simply add new properties of type Item for each new item type,
// whether it's armor, weapons, or other items.
internal class Equipment
{
    public ArmorItem HeadItem { get; set; }
    public ArmorItem BodyItem { get; set; }
    public ArmorItem LegsItem { get; set; }
    public WeaponItem WeaponItem { get; set; }

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

    public static ArmorItem Boots { get; } = new ArmorItem()
    {
        Name = "Boots",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Barbarian },
        Slot = Slot.Legs,
        RequiredLevel = 2,
        ArmorAttribute = 60,
    };

    public static ArmorItem AirForceOne { get; } = new ArmorItem()
    {
        Name = "Air force one",
        WarriorClass = new List<CharacterClass>
        { CharacterClass.Wizard, CharacterClass.Barbarian},
        Slot = Slot.Legs,
        RequiredLevel = 3,
        ArmorAttribute = 7,
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



