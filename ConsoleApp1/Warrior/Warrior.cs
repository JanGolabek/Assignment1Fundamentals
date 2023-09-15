using Assignment1.Warrior.EQ;
using Assignment1.Warrior.EQ.ItemTypes;
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

        public bool CanEquipWeapon(WeaponItem item)
        {
            // Check if the warrior's level is greater than or equal to the item's RequiredLevel
            return Level >= item.RequiredLevel && item.WarriorClass.Contains(Class);
        }

        public bool CanEquipArmor(ArmorItem item)
        {
            // Check if the warrior's level is greater than or equal to the item's RequiredLevel
            return Level >= item.RequiredLevel && item.WarriorClass.Contains(Class);
        }

        public void EquipItem()
        {
            List<WeaponItem> equippableWeapons = new List<WeaponItem>

        {
            Equipment.Sword,
            Equipment.SuperSword,
           
        };

            List<ArmorItem> equippableArmor = new List<ArmorItem>
        {
            Equipment.Plate,
            Equipment.GoldPlate
            // Add more armor pieces as needed
        };

            // Find the best equippable weapon based on the warrior's level

            WeaponItem bestWeapon = equippableWeapons
               .Where(item => item.Slot == Slot.Weapon && CanEquipWeapon(item) && item.RequiredLevel <= Level)
               .OrderByDescending(item => item.WeaponDamage)
               .FirstOrDefault();
            Equipment.WeaponItem = bestWeapon;

           ArmorItem bestBodyItem = equippableArmor
               .Where(item => item.Slot == Slot.Body && CanEquipArmor(item) && item.RequiredLevel <= Level)
               .OrderByDescending(item => item.ArmorAttribute)
               .FirstOrDefault();
            Equipment.BodyItem = bestBodyItem;

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
            // Random random = new Random();
            // Assumes classes start from 1 to 4
            CharacterClass characterClass = // (CharacterClass)random.Next(1, 5);
            CharacterClass.Barbarian;

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
