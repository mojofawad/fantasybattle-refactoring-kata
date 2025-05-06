# Preparatory notes

```csharp
using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        public Inventory Inventory { get; }
        public Stats Stats { get; }

        public Player(Inventory inventory, Stats stats)
        {
            Inventory = inventory;
            Stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            
            int baseDamage = CalculateBaseDamage(); // get base damage sum from all equipped items
            float damageModifier = CalculateDamageModifier(); // get damage modifier sum from all equipped items and strength modifier
            int totalDamage = (int)Math.Round(baseDamage * damageModifier, 0); // multiply and round to the nearest whole number
            int soak = GetSoak(other, totalDamage); // multiply the armor soak and buff soak modifier, round to nearest whole number 
            return new Damage(Math.Max(0, totalDamage - soak)); // damage done to target is total damage, less the soak, with a floor of 0. 
        }

        private int CalculateBaseDamage()
        {
            Equipment equipment = Inventory.Equipment;
            Item leftHand = equipment.LeftHand; 
            Item rightHand = equipment.RightHand;
            Item head = equipment.Head; 
            Item feet = equipment.Feet; 
            Item chest = equipment.Chest;
            return leftHand.BaseDamage +
                   rightHand.BaseDamage +
                   head.BaseDamage +
                   feet.BaseDamage +
                   chest.BaseDamage;
        }

        private float CalculateDamageModifier()
        {
            Equipment equipment = Inventory.Equipment;
            Item leftHand = equipment.LeftHand;
            Item rightHand = equipment.RightHand;
            Item head = equipment.Head;
            Item feet = equipment.Feet;
            Item chest = equipment.Chest;
            float strengthModifier = Stats.Strength * 0.1f;
            return strengthModifier +
                   leftHand.DamageModifier +
                   rightHand.DamageModifier +
                   head.DamageModifier +
                   feet.DamageModifier +
                   chest.DamageModifier;
        }

        private int GetSoak(Target other, int totalDamage)
        {
            int soak = 0;
            if (other is Player)
            {
                // TODO: Not implemented yet
                //  Add friendly fire
                soak = totalDamage;
            }
            else if (other is SimpleEnemy simpleEnemy)
            {
                soak = (int)Math.Round(
                    simpleEnemy.Armor.DamageSoak *
                    (
                        simpleEnemy.Buffs.Select(x => x.SoakModifier).Sum() + 1
                    ), 0
                );
            }

            return soak;
        }
    }
}
```

### TestData in Test Class
```csharp
/*
 * Helpful test data which corresponds to items listed in the top level README file
 */
public class TestData
{
    public static BasicItem shield = new BasicItem("round shield", 0, 1.4f); // won't use for now
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
        [Fact(Skip = "Test is not finished yet")]
        public void DamageCalculations() {
            Inventory inventory = new Inventory(null);
            Stats stats = new Stats(1);
            var player = new Player(inventory, stats);

            Damage damage = player.CalculateDamage(null);
            
            Assert.Equal(9, damage.Amount);
        }
    }
```

## Thoughts before starting
- If the player is equipped with all of starting items, except for the shield, in the test data 
  - Player
    - BaseDamage = 30
    - DamageModifier = 0.1 + 5.2 = 5.3
    - **Total Damage** = 30 * 5.3 = 150 + 9 = 159 (no rounding needed)
  - Enemy
    - Armor Soak = 5
    - Buffs = 3
    - **Total Soak** = 5 * 2 = 10
  - _**Total Damage**_ = 149
