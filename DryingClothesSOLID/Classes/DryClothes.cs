using System.Runtime.InteropServices;
using SOLID.Interfaces;

namespace SOLID
{
    public class DryClothes
    {
        private readonly IDry _itemsDried;
        private readonly IPower _poweredBy;

        public DryClothes(IDry itemsDried, IPower poweredBy)
        {
            _itemsDried = itemsDried;
            _poweredBy = poweredBy;
        }

        public DryClothes(IDry itemsDried)
        {
            _itemsDried = itemsDried;
        }

        public string GetTotalDried()
        {
            return "items dried = " + _itemsDried.GetNumberOfDriedItems();
        }

        public string GetEquipmentUsed()
        {
            return ", dried with " + _itemsDried.EquipmentUsedToDry();
        }

        public string GetPoweredBy()
        {
            try
            {
                if (_poweredBy.GetPoweredBy() != null)
                {
                    return ", powered by " + _poweredBy.GetPoweredBy();
                }
            }

            catch
            {
                
            }

            return "";


        }
    }

}