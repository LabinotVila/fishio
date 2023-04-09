using Attributes;
using UnityEngine;

namespace Unit
{
    public class Player : MonoBehaviour, ISpeciesBehavior
    {
        private Attributes.Player playerAttributes;

        public void Awake()
        {
            playerAttributes = (Attributes.Player) Metadata.GetForFish(Specie.Type.Player);
        }

        public int GetSpeed()
        {
            return playerAttributes.Speed;
        }
    }
}