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
    }
}