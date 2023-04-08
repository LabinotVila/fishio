using System.Collections.Generic;
using UnityEngine;

namespace Attributes
{
    public class Stats : MonoBehaviour
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