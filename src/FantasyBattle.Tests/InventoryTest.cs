using Xunit;

namespace FantasyBattle.Tests;

public class InventoryTest
{
    [Fact]
    public void CalculateBaseDamage_ReturnsCorrectDamage()
    {
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        
        // Act
        var damage = inventory.CalculateBaseDamage();
        
        // Assert
        Assert.Equal(30, damage);
    }
}