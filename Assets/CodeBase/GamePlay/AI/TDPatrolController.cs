using UnityEngine.Events;
using UnityEngine;
using SpaceShooter;

namespace TowerDefence
{
    public class TDPatrolController : AIController
    {
        private Path m_path;
        private int pathIndex;
        [SerializeField] private UnityEvent OnEndPath;
        public void SetPath (Path newPath)
        {
            m_path = newPath;
            pathIndex = 0;
            SetPatrolBehaviour(m_path[pathIndex]);

        }
        protected override void GetNewPoint()
        {

            pathIndex += 1;
            if (m_path.Lenght > pathIndex)
            {
                SetPatrolBehaviour (m_path[pathIndex]);
            }
            else
            {
                OnEndPath.Invoke ();
                Destroy(gameObject);
            }
        }

    }
}


