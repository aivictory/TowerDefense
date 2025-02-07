using UnityEngine;
using Common;

namespace SpaceShooter
{
    public enum TurretMode
    {
        Primary,
        Secondary,
        Auto
    }

    [CreateAssetMenu]
    public sealed class TurretProperties : ScriptableObject
    {
        [SerializeField] private TurretMode m_Mode;
        public TurretMode Mode => m_Mode;

        [SerializeField] private ProjectileBase m_ProjectilePrefab;
        public ProjectileBase ProjectilePrefab => m_ProjectilePrefab;

        [SerializeField] private float m_RateOffFire;
        public float RateOffFire => m_RateOffFire;

        [SerializeField] private int m_EnergyUsage;
        public int EnergyUsage => m_EnergyUsage;

        [SerializeField] private int m_AmmoUsage;
        public int AmmoUsage => m_AmmoUsage;

        [SerializeField] private AudioClip m_LaunchSFX;
        public AudioClip LaunchSFX => m_LaunchSFX;
    }
}