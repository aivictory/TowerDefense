﻿using UnityEngine;
using SpaceShooter;


namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol[] points;
        public int Length { get => points.Length; }
        public AIPointPatrol this[int i] { get => points[i]; }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            foreach (var point in points)
                Gizmos.DrawSphere(point.transform.position, point.Radius);
        }
    }
}