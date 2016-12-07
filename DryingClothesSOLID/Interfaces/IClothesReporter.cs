using System.Collections.Generic;

namespace SOLID.Interfaces
{
    public interface IClothesReporter
    {
        void Print(List<DryClothes> allClothes);
    }

}