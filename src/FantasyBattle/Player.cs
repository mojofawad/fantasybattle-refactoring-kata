using System;
using System.Linq;

namespace FantasyBattle
{
    public class Player : Target
    {
        private readonly Inventory _inventory;
        private readonly Stats _stats;

        public Player(Inventory inventory, Stats stats)
        {
            _inventory = inventory;
            _stats = stats;
        }

        public Damage CalculateDamage(Target target)
        {
            var rawDamage = _inventory.GetTotalRawDamage(_stats.Strength);
            var soak = GetSoak(target, rawDamage);
            
            return new Damage(Math.Max(0, rawDamage - soak));
        }

        private int GetSoak(Target target, int rawDamage)
        {
            int soak = 0;
            if (target is Player)
            {
                // TODO: Not implemented yet
                //  Add friendly fire
                soak = rawDamage;
            }
            else if (target is SimpleEnemy simpleEnemy)
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