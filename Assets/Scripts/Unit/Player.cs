using Unity.VisualScripting;
using UnityEngine;
using Metadata = Attributes.Metadata;

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
        
        // This method will emit onPlayerDeath action
        private void OnCollisionEnter2D(Collision2D col)
        {
            playerAttributes.Health = -1;

            if (playerAttributes.Health <= 0)
            {
                Actions.Type.onPlayerDeath.Invoke();
            }
        }
    }
}