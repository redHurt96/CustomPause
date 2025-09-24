using UnityEngine;
using static UnityEngine.Random;

namespace AwfulVariant.Logic
{
    public class AwfulEntryPoint : MonoBehaviour
    {
        [SerializeField] private Tower _tower;
        [SerializeField] private Enemy _enemyPrefab;
        [SerializeField] private float _radius;
        [SerializeField] private UiView _pauseMenu;
        [SerializeField] private UiView _hud;
        
        private EnemiesRepository _repository;
        private PauseService _pauseService;

        private void Start()
        {
            _repository = new EnemiesRepository();
            _pauseService = new PauseService();
            
            _tower.Setup(_repository);
            _hud.Enable();
            _pauseMenu.Disable();
            
            _pauseMenu.Button.onClick.AddListener(() =>
            {
                _pauseMenu.Disable();
                _hud.Enable();
                _pauseService.Disable();
            });
            
            _hud.Button.onClick.AddListener(() =>
            {
                _hud.Disable();
                _pauseMenu.Enable();
                _pauseService.Enable();
            });
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S) && _tower != null)
                Spawn();
        }

        private void OnDestroy()
        {
            _pauseMenu.Button.onClick.RemoveAllListeners();
            _hud.Button.onClick.RemoveAllListeners();
        }

        private void Spawn()
        {
            Vector3 offset = new(Range(-_radius, _radius), 0, Range(-_radius, _radius));
            Vector3 spawnPosition = _tower.Position + offset;
            Enemy enemy = Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity);
            
            enemy.Setup(_tower, _repository);
            _repository.Add(enemy);
        }
    }
}
