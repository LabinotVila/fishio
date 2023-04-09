namespace Attributes
{
    public class Basic
    {
        public int Speed { get; set;  }
        public int Agility { get; set; }

        public Basic(int speed, int agility)
        {
            Speed = speed;
            Agility = agility;
        }
    }
}