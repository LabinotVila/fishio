using UnityEngine;

namespace Creature.Attributes
{
    [CreateAssetMenu(fileName = "Creature", menuName = "Creature/Attributes")]
    public class SoAttributes : ScriptableObject
    {
        public Attribute health;
        public Attribute agility;
        public Attribute damage;
        public Attribute armor;
    }
}