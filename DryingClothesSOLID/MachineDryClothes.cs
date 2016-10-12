namespace SOLID
{
    public class MachineDryClothes : IDryingMethods
    {
        public int GetNumberOfDriedItems()
        {
            return MachineDriedHelpers.GetNumber();
        }

        public string EquipmentUsedToDry()
        {
            return "Drying Machine";
        }
    }
}