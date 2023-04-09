using System;
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

        public void OnEnable()
        {
            Actions.Type.onPlayerDeath += DoSomethingBczPlayerDied;
        }

        public void OnDisable()
        {
            Actions.Type.onPlayerDeath -= DoSomethingBczPlayerDied;
        }

        public int GetSpeed()
        {
            return attributesAttacher.Speed;
        }

        // These two methods are used just to test Actions Type
        public void DoSomethingBczPlayerDied()
        {
            Debug.Log("Doing something because main player died, even though I'm an NPC");
        }
        
        private void OnCollisionEnter2D()
        {
            Destroy(gameObject);
        }
    }
}