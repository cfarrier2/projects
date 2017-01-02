using System;
using System.Collections;
using System.Collections.Generic;
//test1

//SOLID Analysis
//S - Single Responsibility - Each class has one reason to change. Objects can "save themselves" if needed.
//O - Open/Closed - Depending on interfaces, we are allowing extension by implementing the interface and changing the implementation of the methods.
//L - Liskov Substitution - An AirDryClothes, MachineDryClothes, TwoInOneMachineDry are treated the same as a DryClothes object.
//I - Interface Segregation - Using multiple, segregated interfaces instead of all encompassing ones.
//D - Dependency Inversion - DryClothes only calls from IDry or IPower when needed

namespace SOLID
{
    class Program
    {
        private static DryClothes airDryClothes;
        private static DryClothes machineDryClothes;
        private static DryClothes twoInOneMachineDryClothes;
        private static List<DryClothes> allClothes;
        private static ClothesReporter clothesReporter;

        static void Main(string[] args)
        {
            airDryClothes = new DryClothes(new AirDryClothes());
            machineDryClothes = new DryClothes(new MachineDryClothes(), new SolarPowered());
            twoInOneMachineDryClothes = new DryClothes(new TwoInOneMachineDry(), new GridPowered());
            clothesReporter = new ClothesReporter();


            allClothes = new List<DryClothes>();

            allClothes.Add(airDryClothes);
            allClothes.Add(machineDryClothes);
            allClothes.Add(twoInOneMachineDryClothes);

            clothesReporter.Print(allClothes);


            
            Console.ReadKey();
        }
    }
}
