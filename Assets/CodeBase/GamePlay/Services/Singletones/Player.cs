using SpaceShooter;
using UnityEngine;
using Common;

namespace SpaceShooter
{
    public class Player : SingletonBase<Player>
    {
        public static SpaceShip SelectedSpaceShip;

        [SerializeField] private int m_NumLives;
        [SerializeField] private SpaceShip m_PlayerShipPrefab;

        public SpaceShip ActiveShip => m_Ship;

      //  private FollowCamera m_cameraController;
        //private ShipInputController m_ShipInputController;
        private Transform m_SpawnPoint;

        //public FollowCamera FollowCamera => m_cameraController;

        public void Construct( Transform spawnPoint)
        {
         //   m_cameraController = followCamera;
           // m_ShipInputController = shipInputController;
            m_SpawnPoint = spawnPoint;
        }

        private SpaceShip m_Ship;

        private int m_Score;
        private int m_NumKills;

        public int Score => m_Score;
        public int NumKills => m_NumKills;
        public int NumLives => m_NumLives;

        public SpaceShip ShipPrefab
        {
            get
            {
                if(SelectedSpaceShip == null)
                {
                    return m_PlayerShipPrefab;
                }
                else
                {
                    return SelectedSpaceShip;
                }
            }
        }

        private void Start()
        {
            Respawn();
        }
        private void OnShipDeath()
        {
            m_NumLives--;
            if (m_NumLives > 0)
                Respawn();
        }

        private void Respawn()
        {
            var newPlayerShip = Instantiate(ShipPrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);

            m_Ship = newPlayerShip.GetComponent<SpaceShip>();

           // m_cameraController.SetTarget(m_Ship.transform);
            // m_ShipInputController.SetTargetShip(m_Ship);

            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }

       
        public void AddKill()
        {
            m_NumKills += 1;
        }
        public void AddScore(int num)
        {
            m_Score += num;
        }
    }
}
