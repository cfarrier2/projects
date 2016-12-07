using SOLID.Interfaces;

namespace SOLID
{
    public class SolarPowered : IPower
    {
        public string GetPoweredBy()
        {
            return "solar powered";
        }
    }
}