using Assignment1.Warriors;
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
            Warrior createdWarrior = warrior.CreateWarrior("TestWarrior");

            // Assert
            Assert.NotNull(createdWarrior);
            Assert.Equal("TestWarrior", createdWarrior.Name);
            Assert.Equal(CharacterClass.Barbarian, createdWarrior.Class);
            // Add more assertions for other properties if needed        }
        }
    }
}