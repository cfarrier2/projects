using SOLID.Interfaces;

namespace SOLID
{
    public class AirDryClothes : IDry
    {

        public int GetNumberOfDriedItems()
        {
            return 10;
        }

        public string EquipmentUsedToDry()
        {
            return "Drying Rack";
        }
    }
}