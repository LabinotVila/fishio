using Attributes;
using UnityEngine;
using UnityEngine.Pool;

namespace Spawner
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private SpawnStrategy spawnType;
        public int spawnRadius = 5;
        public int spawnRate = 5;

        public Attacher enemy;
        private const int DefaultEnemyCapacity = 5;
        private const int MaxSize = 30;
        private IObjectPool<Attacher> _objectPool;

        private void Start()
        {
            _objectPool = new ObjectPool<Attacher>(CreateEnemy,
                OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
                true, DefaultEnemyCapacity, MaxSize);
        }

        private Attacher CreateEnemy()
        {
            Attacher enemyObject = Instantiate(enemy);
            enemyObject.ObjectPool = _objectPool;
            return enemyObject;
        }

        private static void OnReleaseToPool(Attacher pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        private static void OnGetFromPool(Attacher pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        private static void OnDestroyPooledObject(Attacher pooledObject)
        {
            Destroy(pooledObject.gameObject);
        }
    }
}