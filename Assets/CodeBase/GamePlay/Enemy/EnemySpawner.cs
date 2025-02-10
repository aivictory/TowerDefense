using UnityEngine;
using SpaceShooter;

namespace TowerDefence
{
    public class EnemySpawner : Spawner
    {
        [SerializeField] private Enemy m_EnemyPrefab;
        [SerializeField] private Path m_path;
        [SerializeField] private EnemyAsset[] m_EnemyAsset;

        
    protected override GameObject GenerateSpawnedEntity()
        {
            var e = Instantiate(m_EnemyPrefab);
            e.Use(m_EnemyAsset[Random.Range(0, m_EnemyAsset.Length)]);
            e.GetComponent<TDPatrolController>().SetPath(m_path);
            return e.gameObject;
        }
    }
}


