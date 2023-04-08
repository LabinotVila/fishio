using System.Collections.Generic;
using UnityEngine;

namespace Attributes
{
    public class Attacher : MonoBehaviour
    {
        [SerializeField] private Specie.Type specieType;
        private Dictionary<Type, ValueGrowth> stats;

        private void Awake()
        {
            stats = Configs.GetForFish(specieType);
        }
        
        public Dictionary<Type, ValueGrowth> GetStats()
        {
            return stats;
        }
    }
}