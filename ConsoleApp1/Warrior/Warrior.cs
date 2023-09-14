using Assignment1.Warrior.EQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1.Warrior
{
    enum CharacterClass
    {
        None,
        Wizard,
        Archer,
        Swashbuckler,
        Barbarian
    }
    class Warrior
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public HeroAttribute Attributes { get; set; }
        public Equipment Equipment { get; set; }
        public int Level { get; set; }

        public int Damage { get; set; }


        public void LevelUp()
        {
            Level++;
            EquipItem(); 
            // Try and equip the items with higher required level each time warrior levels up

            // Increase attributes based on character class
            switch (Class)
            {
                case CharacterClass.Wizard:
                    Attributes.Increase(1, 1, 5); // Increase attributes for a wizard
                    break;
                case CharacterClass.Archer:
                    Attributes.Increase(1, 5, 1); // Increase attributes for an archer
                    break;
                case CharacterClass.Swashbuckler:
                    Attributes.Increase(1, 4, 1); // Increase attributes for a swashbuckler
                    break;
                case CharacterClass.Barbarian:
                    Attributes.Increase(3, 2, 1); // Increase attributes for a barbarian
                    break;
            }
        }

        public bool CanEquipItem(Item item)
        {
            // Check if the warrior's level is greater than or equal to the item's RequiredLevel
            return Level >= item.RequiredLevel;
        }

        public void EquipItem()
        {
            List<Item> equippableItems = new List<Item>
        {
            Equipment.Helmet,
            Equipment.Sword,
            Equipment.SuperSword,
            Equipment.Boots,
            Equipment.SuperHelmet
        };

            // Find the best equippable weapon based on the warrior's level

            Item bestHeadArmor = equippableItems
            .Where(item => item.Slot == Slot.Head && CanEquipItem(item) && item.RequiredLevel <= Level)
            .OrderByDescending(item => item.ItemAttribute)
            .FirstOrDefault();
            Equipment.HeadItem = bestHeadArmor;

            Item bestWeapon = equippableItems
               .Where(item => item.Slot == Slot.Weapon && CanEquipItem(item) && item.RequiredLevel <= Level)
               .OrderByDescending(item => item.ItemAttribute)
               .FirstOrDefault();
            Equipment.WeaponItem = bestWeapon;

            Item helmet = Equipment.Helmet;
            Item superHelmet = Equipment.SuperHelmet;
            Item superSword = Equipment.SuperSword;
            Item sword = Equipment.Sword;
            Item boots = Equipment.Boots;

            //if (CanEquipItem(helmet))
            //{
            //    Equipment.HeadItem = helmet;
            //}

            //if (CanEquipItem(superSword) && (Equipment.Weapon == null || superSword.ItemAttribute > Equipment.Weapon.ItemAttribute))
            //{
            //    Equipment.Weapon = superSword;
            //}

            //if (CanEquipItem(sword))
            //{
            //    Equipment.Weapon = sword;
            //}

            //if (CanEquipItem(boots))
            //{
            //    Equipment.LegsItem = boots;
            //}
        }

        public Warrior CreateWarrior(string name)
        {
            // Generate a random character class
            Random random = new Random();
            // Assumes classes start from 1 to 4
            CharacterClass characterClass = (CharacterClass)random.Next(1, 5);

            HeroAttribute attributes;
            switch (characterClass)
            {
                case CharacterClass.Wizard:
                    attributes = new HeroAttribute(1, 1, 8);
                    break;
                case CharacterClass.Archer:
                    attributes = new HeroAttribute(1, 7, 1);
                    break;
                case CharacterClass.Swashbuckler:
                    attributes = new HeroAttribute(2, 6, 1);
                    break;
                case CharacterClass.Barbarian:
                    attributes = new HeroAttribute(5, 2, 1);
                    break;
                default:
                    attributes = new HeroAttribute(0, 0, 0);
                    break;
            }

            Equipment equipment = new Equipment();
            Warrior warrior = new Warrior()
            {
                Name = name,
                Class = characterClass,
                Attributes = attributes,
                Equipment = equipment,
                Level = 1,
                Damage = 1,
            };
            return warrior;
        }

    }

}
