namespace Attributes
{
    public class Player : Basic
    {
        public int Level { get; set; }
        
        public Player(int speed, int agility, int health, int level) : base(speed, agility, health)
        {
            Level = level;
        }
    }
}