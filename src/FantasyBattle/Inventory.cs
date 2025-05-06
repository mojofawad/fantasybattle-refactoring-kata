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
            var equipment = this.Equipment;
            var leftHand = equipment.LeftHand;
            var rightHand = equipment.RightHand;
            var head = equipment.Head;
            var feet = equipment.Feet;
            var chest = equipment.Chest;
            
            return leftHand.BaseDamage +
                   rightHand.BaseDamage +
                   head.BaseDamage +
                   feet.BaseDamage +
                   chest.BaseDamage;
        }

        public float GetDamageModifier()
        {
            var equipment = Equipment;
            var leftHand = equipment.LeftHand;
            var rightHand = equipment.RightHand;
            var head = equipment.Head;
            var feet = equipment.Feet;
            var chest = equipment.Chest;
            
            return leftHand.DamageModifier +
                rightHand.DamageModifier +
                head.DamageModifier +
                feet.DamageModifier +
                chest.DamageModifier;
        }

        public float CalculateDamageModifier(float strength)
        {
            var strengthModifier = strength * 0.1f;

            var baseEquipmentDamageModifier = GetDamageModifier();
            return strengthModifier + baseEquipmentDamageModifier;

        }

        public int GetTotalRawDamage(float strength)
        {
            var baseDamage = CalculateBaseDamage();
            var damageModifier = CalculateDamageModifier(strength);
            
            return (int)Math.Round(baseDamage * damageModifier, 0);
        }
    }
}