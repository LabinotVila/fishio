namespace Attributes
{
    public class Basic
    {
        public int Speed { get; set;  }
        public int Agility { get; set; }
        public int Health { get; set; }

        public Basic(int speed, int agility, int health)
        {
            Speed = speed;
            Agility = agility;
            Health = health;
        }
    }
}