using System;

namespace FantasyBattle
{
    public class Inventory
    {
        public virtual Equipment Equipment { get; }

        public Inventory(Equipment equipment)
        {
            Equipment = equipment;
        }

        public int CalculateBaseDamage()
        {
            Equipment equipment = this.Equipment;
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

        public float CalculateDamageModifier(Stats playerStats)
        {
            Equipment equipment = this.Equipment;
            Item leftHand = equipment.LeftHand;
            Item rightHand = equipment.RightHand;
            Item head = equipment.Head;
            Item feet = equipment.Feet;
            Item chest = equipment.Chest;
            float strengthModifier = playerStats.Strength * 0.1f;
            return strengthModifier +
                   leftHand.DamageModifier +
                   rightHand.DamageModifier +
                   head.DamageModifier +
                   feet.DamageModifier +
                   chest.DamageModifier;
        }

        public int GetTotalRawDamage(Player player)
        {
            var baseDamage = this.CalculateBaseDamage();
            var damageModifier = this.CalculateDamageModifier(player.Stats);
            
            return (int)Math.Round(baseDamage * damageModifier, 0);
        }
    }
}