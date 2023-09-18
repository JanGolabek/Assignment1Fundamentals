using Assignment1.Warriors.EQ;
using Assignment1.Warriors.EQ.Items;
using Assignment1.Warriors.EQ.Items.ItemTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment1.Warriors
{
   public enum CharacterClass
    {
        None,
        Wizard,
        Archer,
        Swashbuckler,
        Barbarian
    }
    public class Warrior
    {
        public string Name { get; set; }
        public CharacterClass Class { get; set; }
        public HeroAttribute Attributes { get; set; }
        public Equipment Equipment { get; set; }
        public int Level { get; set; }

        public int Damage { get; set; }


        public void SetAttributes(HeroAttribute totalAttributes)
        {
            Attributes = totalAttributes;
        }

        public Warrior()
        {
            // Initialize the Equipment property
            Equipment = new Equipment();
        }

        public void LevelUp()
        {
            Level++;

            // EquipItem();
            CalculateTotalDamage();

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
            HeroAttribute totalAttributes = CalculateTotalAttributes();
            SetAttributes(totalAttributes);
        }

        public class InvalidWeaponException : Exception
        {
            public InvalidWeaponException(string message) : base(message)
            {
            }
        }

        public class InvalidArmorException : Exception
        {
            public InvalidArmorException(string message) : base(message)
            {
            }
        }


        // Common base class Item, both WeaponItem and
        // ArmorItem inherit from it. This allows the code to use the
        // generic CanEquipItem method for both weapon and armor items:
        public bool CanEquipWeapon(WeaponItem weaponItem)
        {
            // Check if the warrior's level is greater than or equal to the item's RequiredLevel
            return Level >= weaponItem.RequiredLevel && CanEquipWeaponType(weaponItem.WeaponType);
        }

        public bool CanEquipArmor(ArmorItem armorItem)
        {
            // Check if the warrior's level is greater than or equal to the item's RequiredLevel
            return Level >= armorItem.RequiredLevel && CanEquipArmorType(armorItem.ArmorType);
        }

        public bool CanEquipWeaponType(WeaponType weaponType)
        {
            // Define which classes can equip which weapon types
            switch (Class)
            {
                case CharacterClass.Wizard:
                    return weaponType == WeaponType.Staff || weaponType == WeaponType.Wand;
                case CharacterClass.Archer:
                    return weaponType == WeaponType.Bow;
                case CharacterClass.Swashbuckler:
                    return weaponType == WeaponType.Dagger || weaponType == WeaponType.Sword;
                case CharacterClass.Barbarian:
                    return weaponType == WeaponType.Hatchet || weaponType == WeaponType.Mace || weaponType == WeaponType.Sword;
                default:
                    return false; // Invalid class
            }
        }

        public bool CanEquipArmorType(ArmorType armorType)
        {
            // Define which classes can equip which weapon types
            switch (Class)
            {
                case CharacterClass.Wizard:
                    return armorType == ArmorType.Cloth;
                case CharacterClass.Archer:
                    return armorType == ArmorType.Leather || armorType == ArmorType.Mail;
                case CharacterClass.Swashbuckler:
                    return armorType == ArmorType.Leather || armorType == ArmorType.Mail;
                case CharacterClass.Barbarian:
                    return armorType == ArmorType.Mail || armorType == ArmorType.Plate;
                default:
                    return false; // Invalid class
            }
        }


        public void EquipItem(List<Item> equippableItems)
        {

            // Find the best equippable weapon and armor based on the warrior's level

            Equipment.WeaponItem = FindBestWeapon(equippableItems);
            Equipment.HeadItem = FindBestArmor(Slot.Head, equippableItems);
            Equipment.BodyItem = FindBestArmor(Slot.Body, equippableItems);
            Equipment.LegsItem = FindBestArmor(Slot.Legs, equippableItems);

            // Calculate the new total attributes
            HeroAttribute totalAttributes = CalculateTotalAttributes();
            SetAttributes(totalAttributes);

        }



        // Refactored the FindBestArmor method at the class level

        // Private Access Modifier: The private access modifier is used to restrict
        // the visibility of the method to within the Warrior class. This means that
        // the method can only be called from within the Warrior class itself and
        // not from outside classes or methods. Since this method is intended to
        // be used internally within the Warrior class, it makes sense to keep it private.
        private ArmorItem FindBestArmor(Slot slot, List<Item> equippableItems)
        {
            return equippableItems
                .Where(item => item is ArmorItem armorItem && armorItem.Slot == slot && CanEquipArmor(armorItem))
                .OrderByDescending(item => (item as ArmorItem)?.ArmorAttribute.Strength +
                                         (item as ArmorItem)?.ArmorAttribute.Dexterity +
                                         (item as ArmorItem)?.ArmorAttribute.Intelligence)
                .FirstOrDefault() as ArmorItem;
        }


        private WeaponItem FindBestWeapon(List<Item> equippableItems)
        {
            return equippableItems
                .Where(item => item is WeaponItem weaponItem && item.Slot == Slot.Weapon && CanEquipWeapon(weaponItem))
                .OrderByDescending(item => (item as WeaponItem)?.WeaponDamage ?? 0)
                .FirstOrDefault() as WeaponItem;
        }


        public Warrior CreateWarrior(string name, CharacterClass characterClass)
        {
            
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
                Level = 0,
                Damage = 1,
            };
            return warrior;
        }
        public HeroAttribute CalculateTotalAttributes()
        {
            // Calculate the sum of leveling attributes
            int levelingStrength = Attributes.Strength;
            int levelingDexterity = Attributes.Dexterity;
            int levelingIntelligence = Attributes.Intelligence;

            // Calculate the sum of armor attributes from equipment
            int equipmentStrength = 0;
            int equipmentDexterity = 0;
            int equipmentIntelligence = 0;

            if (Equipment != null)
            {
                // Access the armor items in each slot directly
                ArmorItem headArmor = Equipment.HeadItem;
                ArmorItem bodyArmor = Equipment.BodyItem;
                ArmorItem legsArmor = Equipment.LegsItem;

                // Check and add the armor attribute values for each equipped armor item
                if (headArmor != null)
                {
                    equipmentStrength += headArmor.ArmorAttribute.Strength;
                    equipmentDexterity += headArmor.ArmorAttribute.Dexterity;
                    equipmentIntelligence += headArmor.ArmorAttribute.Intelligence;
                }

                if (bodyArmor != null)
                {
                    equipmentStrength += bodyArmor.ArmorAttribute.Strength;
                    equipmentDexterity += bodyArmor.ArmorAttribute.Dexterity;
                    equipmentIntelligence += bodyArmor.ArmorAttribute.Intelligence;
                }

                if (legsArmor != null)
                {
                    equipmentStrength += legsArmor.ArmorAttribute.Strength;
                    equipmentDexterity += legsArmor.ArmorAttribute.Dexterity;
                    equipmentIntelligence += legsArmor.ArmorAttribute.Intelligence;
                }
            }

            // Calculate the total attributes as a HeroAttribute object
            HeroAttribute totalAttributes = new HeroAttribute
            {
                Strength = levelingStrength + equipmentStrength,
                Dexterity = levelingDexterity + equipmentDexterity,
                Intelligence = levelingIntelligence + equipmentIntelligence
            };

            return totalAttributes;
        }


        public void CalculateTotalDamage()
        {
            // Default weapon damage if no weapon is equipped
            int defaultWeaponDamage = 1;

            // Find the equipped weapon or set to null if no weapon is equipped
            WeaponItem equippedWeapon = Equipment.WeaponItem;

            // Calculate damaging attribute based on character class
            int damagingAttribute = 0;
            switch (Class)
            {
                case CharacterClass.Wizard:
                    damagingAttribute = Attributes.Intelligence;
                    break;
                case CharacterClass.Archer:
                case CharacterClass.Swashbuckler:
                    damagingAttribute = Attributes.Dexterity;
                    break;
                case CharacterClass.Barbarian:
                    damagingAttribute = Attributes.Strength;
                    break;
            }

            // Calculate total damage based on equipped weapon and damaging attribute
            int totalDamage = equippedWeapon != null
                ? (int)(equippedWeapon.WeaponDamage * (1 + damagingAttribute / 100.0))
                : defaultWeaponDamage;

            // Update the warrior's damage property
            Damage = totalDamage;
        }

    }


}


