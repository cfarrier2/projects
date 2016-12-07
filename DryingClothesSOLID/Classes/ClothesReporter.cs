using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SOLID.Interfaces;

namespace SOLID
{
    public class ClothesReporter : IClothesReporter
    {
        public void Print(List<DryClothes> allClothes)
        {
            foreach (DryClothes item in allClothes)
            {
//                Console.WriteLine("{0} dried with {1}",
//                    item.GetTotalDried(), item.GetEquipmentUsed());
                Console.WriteLine(item.GetTotalDried() + item.GetEquipmentUsed() + item.GetPoweredBy());

                //How can I determine if a DryClothes item has access to the GetPoweredBy method?

            }
        }

    }
}

