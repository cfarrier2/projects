using System.Runtime.InteropServices;

namespace SOLID
{
    public class DryClothes
    {
        private readonly IDryingMethods _itemsDried;
        private IPowerMethods _poweredBy;

        public DryClothes(IDryingMethods itemsDried, IPowerMethods poweredBy)
        {
            _itemsDried = itemsDried;
            _poweredBy = poweredBy;
        }

        public DryClothes(IDryingMethods itemsDried)
        {
            _itemsDried = itemsDried;
        }

        public int GetTotalDried()
        {
            return _itemsDried.GetNumberOfDriedItems();
        }

        public string GetEquipmentUsed()
        {
            return _itemsDried.EquipmentUsedToDry();
        }

        public string GetPoweredBy()
        {
            return _poweredBy.GetPoweredBy();
        }
    }
}