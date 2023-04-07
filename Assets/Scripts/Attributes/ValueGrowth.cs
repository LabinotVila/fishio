namespace Attributes
{
    public class ValueGrowth
    {
        private readonly int value;
        private readonly double growthFactor;

        public ValueGrowth(int value, double growthFactor)
        {
            this.value = value;
            this.growthFactor = growthFactor;
        }

        public int GetValue()
        {
            return value;
        }

        public double GetGrowthFactor()
        {
            return growthFactor;
        }
    }
}