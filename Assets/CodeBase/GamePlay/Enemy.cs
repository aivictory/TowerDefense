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

            //��������� ����
            sr.color = asset.color;

            //��������� ������ �������
            sr.transform.localScale = new Vector3(asset.spriteScale.x, asset.spriteScale.y, 1);

            //��������� �������� (��� �� �������� �������� ��� ��������)
            sr.GetComponent<Animator>().runtimeAnimatorController = asset.animations;

            //����������� �������������� �� ���������
            GetComponent<SpaceShip>().Use(asset);

            //����������� ���������
            var circleCollider = GetComponentInChildren<CircleCollider2D>();
            circleCollider.radius = asset.radius;

            // ��������� �������� ������ ����������
            Vector3 modelWorldPos = sr.transform.position;  
            Vector3 colliderWorldPos = circleCollider.transform.position; 

            // ������������ ��������
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


