using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        private Inventory Inventory { get; }
        public Stats Stats { get; }

        public Player(Inventory inventory, Stats stats)
        {
            Inventory = inventory;
            Stats = stats;
        }

        public Damage CalculateDamage(Target other)
        {
            var totalDamage = Inventory.GetTotalRawDamage(this);
            int soak = GetSoak(other, totalDamage);
            return new Damage(Math.Max(0, totalDamage - soak));
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