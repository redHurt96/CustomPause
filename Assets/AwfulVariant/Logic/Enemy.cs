using UnityEngine;
using UnityEngine.AI;

namespace AwfulVariant.Logic
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _damage;
        
        private Tower _tower;
        private float _currentAttackCooldown;
        private EnemiesRepository _repository;

        public void Setup(Tower tower, EnemiesRepository repository)
        {
            _repository = repository;
            _tower = tower;
            GetComponent<NavMeshAgent>().SetDestination(_tower.Position);
        }

        private void Update()
        {
            float distanceSqr = (_tower.Position - transform.position).sqrMagnitude;
            
            if (distanceSqr <= _attackRadius * _attackRadius && _currentAttackCooldown <= 0f)
            {
                _tower.TakeDamage(_damage);
                _currentAttackCooldown = _attackCooldown;
            }
            
            if (_currentAttackCooldown > 0f)
                _currentAttackCooldown -= Time.deltaTime;
        }

        private void OnDestroy() => 
            _repository.Remove(this);

        public void TakeDamage() => 
            Destroy(gameObject);
    }
}