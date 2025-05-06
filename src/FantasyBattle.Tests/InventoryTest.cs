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
        var player = new Player(new Inventory(equipment), new Stats(1));
        
        // Act
        var damageModifier = inventory.CalculateDamageModifier(player.Stats);
        
        // Assert 
        Assert.Equal(5.3f, damageModifier, 4); // floating point values need to be rounded
    }
    
    [Fact]
    public void GetTotalRawDamage_ReturnsCorrectDamage()
    {
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        var player = new Player(new Inventory(equipment), new Stats(1));
        
        // Act
        var damage = inventory.GetTotalRawDamage(player);
        
        // Assert
        Assert.Equal(159, damage);
    }

    [Fact]
    public void GetDamageModifier_ReturnsCorrectDamageModifier()
    {
        // Arrange
        // Arrange
        var equipment = new Equipment(TestData.sword, TestData.excalibur, TestData.helmet, TestData.boots, TestData.breastplate);
        var inventory = new Inventory(equipment);
        var player = new Player(new Inventory(equipment), new Stats(1));
        
        // Act
        var damageModifier = inventory.GetDamageModifier();
        
        // Assert 
        Assert.Equal(5.2f, damageModifier, 4); // floating point values need to be rounded
    }
}