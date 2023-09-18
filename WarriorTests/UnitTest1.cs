using Assignment1.Warriors;
using Assignment1.Warriors.EQ.Items.ItemTypes;
using Assignment1.Warriors.EQ;
using System.Threading;

namespace WarriorTests
{
    public class UnitTest1
    {
        [Fact]
        public void CreateWarrior_Should_Return_Valid_Warrior_For_Barbarian()
        {
            // Arrange
            Warrior warrior = new Warrior();

            // Act
            Warrior createdWarrior = warrior.CreateWarrior("TestWarrior", CharacterClass.Barbarian);

            // Assert
            Assert.NotNull(createdWarrior);
            Assert.Equal("TestWarrior", createdWarrior.Name);
            Assert.Equal(CharacterClass.Barbarian, createdWarrior.Class);
            // Add more assertions for other properties if needed        }
        }

        [Fact]
        public void CreateWarrior_Wizard_CreatesWizardWithCorrectAttributes()
        {
            // Arrange
            Warrior warrior = new Warrior();

            // Act
            Warrior createdWarrior = warrior.CreateWarrior("TestWizard", CharacterClass.Wizard);

            // Assert
            Assert.Equal("TestWizard", createdWarrior.Name);
            Assert.Equal(CharacterClass.Wizard, createdWarrior.Class);
            Assert.Equal(1, createdWarrior.Attributes.Strength);
            Assert.Equal(1, createdWarrior.Attributes.Dexterity);
            Assert.Equal(8, createdWarrior.Attributes.Intelligence);
        }

        [Fact]
        public void LevelUp_Wizard_IncreasesAttributesCorrectly()
        {
            // Arrange
            Warrior warrior = new Warrior();
            Warrior createdWarrior = warrior.CreateWarrior("TestWizard", CharacterClass.Wizard);

            // Act
            createdWarrior.LevelUp();

            // Assert
            Assert.Equal(2, createdWarrior.Attributes.Strength);
            Assert.Equal(2, createdWarrior.Attributes.Dexterity);
            Assert.Equal(13, createdWarrior.Attributes.Intelligence);
        }

        [Fact]
        public void WeaponShouldHaveCorrectProperties()
        {
            // Arrange
            string expectedName = "Sword of Power";
            int expectedRequiredLevel = 10;
            Slot expectedSlot = Slot.Weapon;
            WeaponType expectedWeaponType = WeaponType.Sword;
            int expectedDamage = 20;

            // Act
            WeaponItem weapon = new WeaponItem
            {
                Name = expectedName,
                RequiredLevel = expectedRequiredLevel,
                Slot = expectedSlot,
                WeaponType = expectedWeaponType,
                WeaponDamage = expectedDamage
            };

            // Assert
            Assert.Equal(expectedName, weapon.Name);
            Assert.Equal(expectedRequiredLevel, weapon.RequiredLevel);
            Assert.Equal(expectedSlot, weapon.Slot);
            Assert.Equal(expectedWeaponType, weapon.WeaponType);
            Assert.Equal(expectedDamage, weapon.WeaponDamage);
        }

        [Fact]

        public void ArmorShouldHaveCorrectProperties()
        {
            // Arrange
            string expectedName = "Basic Helmet";
            int expectedRequiredLevel = 10;
            Slot expectedSlot = Slot.Head;
            ArmorType expectedArmorType = ArmorType.Cloth;
            HeroAttribute expectedArmorAttribute = new HeroAttribute(120, 120, 120);

            // Act
            ArmorItem armor = new ArmorItem
            {
                Name = expectedName,
                RequiredLevel = expectedRequiredLevel,
                Slot = expectedSlot,
                ArmorType = expectedArmorType,
                ArmorAttribute = expectedArmorAttribute
            };

            // Assert
            Assert.Equal(expectedName, armor.Name);
            Assert.Equal(expectedRequiredLevel, armor.RequiredLevel);
            Assert.Equal(expectedSlot, armor.Slot);
            Assert.Equal(expectedArmorType, armor.ArmorType);
            Assert.Equal(expectedArmorAttribute, armor.ArmorAttribute);
        }

    }
}