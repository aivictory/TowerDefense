using UnityEngine;

namespace TowerDefence
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {

        [Header("������� ���")]
        public Color color = Color.white;
        public Vector2 spriteScale = new Vector2(3, 3);
        public RuntimeAnimatorController animations;

        [Header("������� ���������")]
        public float moveSpeed = 1;
        public int hp = 1;
        public int score = 1;
        public float radius = 0.19f;
        public int damage = 1;
        public int gold = 1;

    }
}