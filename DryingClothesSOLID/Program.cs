using System;
using System.Collections;

//S  - IDryingMethods provides GetTotalDried and also GetEquipmentUsed.  Both of these could change.  I suppose that is a violation of the single responsibility principle
//     because one or the other could have a reason to change.
//O  - While making this, I realized that I could very easily add IPoweredBy.  I didn't have to change any existing source code. "DryClothes" can be extended by injecting
//     new interfaces to it.
//L  - This should not be a problem. As long as interfaces force the implementation of methods.
//I  - It is probably a problem that IDryingMethods returns the amount of clothes dried as well as the actual drying method... Interfaces could be segregated further.
//D  - Dependency inversion is implemented. Implementations are not based on concrete classes, but on interfaces.

namespace SOLID
{
    class Program
    {
        private static DryClothes airDryClothes;
        private static DryClothes machineDryClothes;
        private static DryClothes twoInOneMachineDryClothes;
        private static DryClothes[] allClothes;

        static void Main(string[] args)
        {
            airDryClothes = new DryClothes(new AirDryClothes(), new NonPowered());
            machineDryClothes = new DryClothes(new MachineDryClothes(), new SolarPowered());
            twoInOneMachineDryClothes = new DryClothes(new TwoInOneMachineDry(), new GridPowered());


            allClothes = new DryClothes[3];

            allClothes[0] = airDryClothes;
            allClothes[1] = machineDryClothes;
            allClothes[2] = twoInOneMachineDryClothes;

            for (int i = 0; i < allClothes.Length; i++)
            {
                Console.WriteLine("{0} dried with {1}, and powered by {2}", 
                    allClothes[i].GetTotalDried(), allClothes[i].GetEquipmentUsed(), allClothes[i].GetPoweredBy());
            }
            
            Console.ReadKey();
        }
    }
}
