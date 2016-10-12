namespace SOLID
{
    public class NonPowered : IPowerMethods
    {
        public string GetPoweredBy()
        {
            return "nothing";
        }
    }
}