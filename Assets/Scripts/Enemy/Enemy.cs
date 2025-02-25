using UnityEngine;
using SpaceShooter;
using UnityEditor;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]

    public class Enemy : MonoBehaviour

    {
        [SerializeField] private int m_damage = 1;
        [SerializeField] private int m_gold = 1;
        public void Use(EnemyAsset asset)
        {
            var sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();

            //Назначаем цвет
            sr.color = asset.color;

            //Назначаем размер Спрайта
            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1);

            //Назначаем анимацию (она же забирает контроль над спрайтом)
            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;

            //Запрашиваем характеристики из спейсшипа
            GetComponent<SpaceShip>().Use(asset);

            //Запрашиваем коллайдер
            var circleCollider = GetComponentInChildren<CircleCollider2D>();
            circleCollider.radius = asset.radius;

            // Вычисляем смещение центра коллайдера
            Vector3 modelWorldPos = sr.transform.position;
            Vector3 colliderWorldPos = circleCollider.transform.position;

            // Рассчитываем смещение
            Vector3 offset = modelWorldPos - colliderWorldPos;
            circleCollider.offset = new Vector2(offset.x, offset.y);

            // Назначаем кол-во урона от врага
            m_damage = asset.damage;
            m_gold = asset.gold;
        }
        // Наносим повреждения игроку
        public void DamagePlayer()
        {
            TDPlayer.Instance.ReduceLife(m_damage);
        }

        public void GivePlayerGold()
        {

            TDPlayer.Instance.ChangeGold(m_gold);

        }
    }

    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EnemyAsset a = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;

            if (a)
            {
                (target as Enemy).Use(a);
            }
        }
    }
}


