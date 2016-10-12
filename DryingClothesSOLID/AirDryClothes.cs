namespace SOLID
{
    public class AirDryClothes : IDryingMethods
    {

        public int GetNumberOfDriedItems()
        {
            return AirDriedHelpers.GetNumber();
        }

        public string EquipmentUsedToDry()
        {
            return "Drying Rack";
        }
    }
}