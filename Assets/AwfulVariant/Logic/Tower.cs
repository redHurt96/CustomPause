using UnityEngine;

namespace AwfulVariant.Logic
{
    public class Tower : MonoBehaviour
    {
        public Vector3 Position => new(transform.position.x, 0, transform.position.z);
        
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _health;
        
        private EnemiesRepository _repository;
        private float _currentAttackCooldown;

        public void Setup(EnemiesRepository repository) => 
            _repository = repository;

        private void Update()
        {
            if (_repository.IsEmpty)
                return;
            
            if (_currentAttackCooldown <= 0f)
            {
                _repository
                    .GetClosest(Position)
                    .TakeDamage();
                _currentAttackCooldown = _attackCooldown;
            }
            
            if (_currentAttackCooldown > 0f)
                _currentAttackCooldown -= Time.deltaTime;
        }

        public void TakeDamage(float damage)
        {
            _health = Mathf.Max(_health - damage, 0f);
            
            if (Mathf.Approximately(_health, 0f))
                Destroy(gameObject);
        }
    }
}