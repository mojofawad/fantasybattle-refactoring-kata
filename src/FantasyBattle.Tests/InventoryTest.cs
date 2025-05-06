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
    
    [Fact]
    public void CalculateDamageModifier_ReturnsCorrectDamageModifier()
    {
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        
        // Act
        var damageModifier = inventory.CalculateDamageModifier(1);
        
        // Assert 
        Assert.Equal(5.3f, damageModifier, 4); // floating point values need to be rounded
    }
    
    [Fact]
    public void GetTotalRawDamage_ReturnsCorrectDamage()
    {
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        
        // Act
        var damage = inventory.GetTotalRawDamage(1);
        
        // Assert
        Assert.Equal(159, damage);
    }

    [Fact]
    public void GetDamageModifier_ReturnsCorrectDamageModifier()
    {
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        
        // Act
        var damageModifier = inventory.GetDamageModifier();
        
        // Assert 
        Assert.Equal(5.2f, damageModifier, 4); // floating point values need to be rounded
    }
}