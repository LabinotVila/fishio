using Attributes;
using UnityEngine;

namespace Unit
{
    public class Npc : MonoBehaviour, ISpeciesBehavior
    {
        [SerializeField] private Specie.Type type;
        private Basic attributesAttacher;

        public void Awake()
        {
            attributesAttacher = Metadata.GetForFish(type);
        }

        public int GetSpeed()
        {
            return attributesAttacher.Speed;
        }
    }
}