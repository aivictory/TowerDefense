using UnityEngine;
using SpaceShooter;
using UnityEditor;

namespace TowerDefence
{
    [RequireComponent(typeof(TDPatrolController))]

    public class Enemy : MonoBehaviour

    {
        public void Use (EnemyAsset asset)
        {
            var sr = transform.Find("VisualModel").GetComponent <SpriteRenderer>();

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


