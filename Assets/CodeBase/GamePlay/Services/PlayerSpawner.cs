using Common;
using UnityEngine;


namespace SpaceShooter
{
    public class PlayerSpawner : MonoBehaviour
    {
        [Header("Prefab")]
       // [SerializeField] private FollowCamera m_FollowCameraPrefab;
        [SerializeField] private Player m_PlayerPrefab;
       // [SerializeField] private ShipInputController m_shipinputController;
        [SerializeField] private VirtualGamepad m_VirtualGamePad;
        [SerializeField] private Transform m_SpawnPoint;



        public Player Spawn()
        {
         //   FollowCamera followCamera = Instantiate(m_FollowCameraPrefab);
            VirtualGamepad virtualGamepad = Instantiate(m_VirtualGamePad);

          //  ShipInputController shipInputController = Instantiate(m_shipinputController);
         //   shipInputController.Construct(virtualGamepad);

            Player player = Instantiate(m_PlayerPrefab);
            player.Construct(m_SpawnPoint);

            return player;
        }
    }
}
