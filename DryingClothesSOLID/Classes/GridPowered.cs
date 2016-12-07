using SOLID.Interfaces;

namespace SOLID
{
    public class GridPowered : IPower
    {
        public string GetPoweredBy()
        {
            return "grid powered";
        }
    }
}