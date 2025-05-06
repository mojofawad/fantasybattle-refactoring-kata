using System.Collections.Generic;
using System.Text;
using Moq;
using NSubstitute;
using Xunit;

namespace FantasyBattle.Tests
{
    /*
     * Helpful test data which corresponds to items listed in the top level README file
     */
    public class TestData
    {
        public static BasicItem shield = new BasicItem("round shield", 0, 1.4f);
        public static BasicItem sword = new BasicItem("Flashy sword of danger", 10, 1.0f);
        public static BasicItem excalibur = new BasicItem("Excalibur", 20, 1.5f);
        public static BasicItem helmet = new BasicItem("helmet of swiftness", 0, 1.2f);
        public static BasicItem boots = new BasicItem("ten league boots", 0, 0.1f);
        public static BasicItem breastplate = new BasicItem("breastplate of steel", 0, 1.4f);
        public static SimpleEnemy enemy = new SimpleEnemy(
            new SimpleArmor(5), 
            new List<Buff>() {new BasicBuff(1.0f, 1.0f)}
            );
    }
    
    public class PlayerTest
    {
        [Fact]
        public void DamageCalculations_TargetIsBasicEnemy_CalculatesDamage() 
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
