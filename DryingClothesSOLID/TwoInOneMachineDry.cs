namespace SOLID
{
    public class TwoInOneMachineDry : IDryingMethods
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