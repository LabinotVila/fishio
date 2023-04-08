using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Attributes
{
    public class Attacher : MonoBehaviour
    {
        [SerializeField] private Specie.Type specieType;
        private Dictionary<Type, ValueGrowth> stats;
        private IObjectPool<Attacher> _objectPool;
        
        public IObjectPool<Attacher> ObjectPool
        {
            set => _objectPool = value;
        }

        public void OnDeath()
        {
            _objectPool.Release(this);
        }
        
        private void Start()
        {
            stats = Configs.GetForFish(specieType);
        }

        public Dictionary<Type, ValueGrowth> GetStats()
        {
            return stats;
        }
    }
}