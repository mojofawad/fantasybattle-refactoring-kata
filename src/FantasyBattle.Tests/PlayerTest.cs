using System.Text;
using Moq;
using NSubstitute;
using Xunit;

namespace FantasyBattle.Tests
{
    /*
     * Helpful test data which corresponds to items listed in the top level README file
     */

    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations_TargetIsBasicEnemy_ReturnsCorrectDamage() 
        {
            // Arrange
            var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
            var inventory = new Inventory(equipment);
            var stats = new Stats(1);
            var player = new Player(inventory, stats);
            var targetEnemy = TestData.enemy;
            
            // Act
            var damage = player.CalculateDamage(targetEnemy);
            
            // Assert
            Assert.Equal(149, damage.Amount);
        }

        [Fact]
        public void DamageCalculations_TargetIsPlayer_ReturnsZeroDamage()
        {
            // Arrange
            var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
            var inventory = new Inventory(equipment);
            var stats = new Stats(1);
            var player = new Player(inventory, stats);
            var targetPlayer = new Player(inventory, stats);
            
            // Act
            var damage = player.CalculateDamage(targetPlayer);
            
            // Assert
            Assert.Equal(0, damage.Amount);
        }
    }
}
