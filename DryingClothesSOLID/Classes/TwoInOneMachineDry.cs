using SOLID.Interfaces;

namespace SOLID
{
    public class TwoInOneMachineDry : IDry
    {
        public int GetNumberOfDriedItems()
        {
            return 15;
        }

        public string EquipmentUsedToDry()
        {
            return "Two In One Machine";
        }
    }
}