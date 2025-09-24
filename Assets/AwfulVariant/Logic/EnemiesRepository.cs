using System.Collections.Generic;
using UnityEngine;

namespace AwfulVariant.Logic
{
    public class EnemiesRepository
    {
        public bool IsEmpty => Enemies.Count == 0;
        private List<Enemy> Enemies { get; } = new();

        public void Add(Enemy enemy) => 
            Enemies.Add(enemy);

        public void Remove(Enemy enemy) => 
            Enemies.Remove(enemy);

        public Enemy GetClosest(Vector3 to)
        {
            Enemy closest = null;
            float closestDistanceSqr = float.MaxValue;

            foreach (Enemy enemy in Enemies)
            {
                float distanceSqr = (enemy.transform.position - to).sqrMagnitude;
                if (distanceSqr < closestDistanceSqr)
                {
                    closest = enemy;
                    closestDistanceSqr = distanceSqr;
                }
            }

            return closest;
        }
    }
}