using SOLID.Interfaces;

namespace SOLID
{
    public class MachineDryClothes : IDry
    {
        public int GetNumberOfDriedItems()
        {
            return 5;
        }

        public string EquipmentUsedToDry()
        {
            return "Drying Machine";
        }
    }
}