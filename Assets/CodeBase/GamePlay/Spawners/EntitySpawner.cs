using UnityEngine;
using Common;
using TowerDefence;

namespace SpaceShooter
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Path m_path;
        public enum SpawnMode
        {
            Start,
            Loop
        }

        [SerializeField] private Entity[] m_EntityPrefabs;
        [SerializeField] private CircleArea m_Area;
        [SerializeField] private SpawnMode m_SpawnMode;
        [SerializeField] private int m_NumSpawns;
        [SerializeField] private float m_RespawnTime;
        private float m_Timer;

        private void Start()
        {
            if (m_SpawnMode == SpawnMode.Start)
            {
                SpawnEntities();
            }

            m_Timer = m_RespawnTime;
        }

        private void Update()
        {
            if (m_Timer > 0)
                m_Timer -= Time.deltaTime;

            if (m_SpawnMode == SpawnMode.Loop && m_Timer <= 0)
            {
                SpawnEntities();

                m_Timer = m_RespawnTime;
            }
        }

        private void SpawnEntities()
        {
            for (int i = 0; i < m_NumSpawns; i++)
            {
                var prefabToSpawn = m_EntityPrefabs[UnityEngine.Random.Range(0, m_EntityPrefabs.Length)];
                var e = Instantiate(prefabToSpawn);

                e.transform.position = m_Area.GetRandomInsideZone();

                if (e.TryGetComponent<TDPatrolController>(out var ai))
                {
                    ai.SetPath(m_path);
                }
            }
        }
    }
}