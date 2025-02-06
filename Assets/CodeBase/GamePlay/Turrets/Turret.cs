using UnityEngine;
using Common;

namespace SpaceShooter
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] TurretMode m_Mode;
        public TurretMode Mode => m_Mode;

        [SerializeField] private TurretProperties m_TurretProperties;

        private float m_RefireTimer;

        public bool CanFire => m_RefireTimer <= 0;

        private SpaceShip m_Ship;

        #region UNITY EVENT
        private void Start()
        {
            m_Ship = transform.root.GetComponent<SpaceShip>();
        }

        private void Update()
        {
            if (m_RefireTimer > 0)
                m_RefireTimer -= Time.deltaTime;
        }
        #endregion

        public void Fire()
        {
            if (m_TurretProperties == null) return;

            if (m_RefireTimer > 0) return;

            if (m_Ship.DrawEnergy(m_TurretProperties.EnergyUsage) == false)
                return;

            ProjectileBase projectile = Instantiate(m_TurretProperties.ProjectilePrefab).GetComponent<ProjectileBase>();
            projectile.transform.position = transform.position;
            projectile.transform.up = transform.up;

            projectile.SetParentShooter(m_Ship);

            m_RefireTimer = m_TurretProperties.RateOffFire;

            {
                // ��� ����� ����� ��������.
            }
        }

        public void AssignLoadout(TurretProperties props)
        {
            if (m_Mode != props.Mode) return;

            m_RefireTimer = 0;
            m_TurretProperties = props;
        }
    }
}