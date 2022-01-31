using StackFall.Cam;
using StackFall.LevelSystem;
using StackFall.PlayerSystem;
using StackFall.TubeSystem;
using StackFall.TubeSystem.Shapes;
using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Player _playerPrefab;
        [SerializeField] private Tube _tubePrefab;
        [SerializeField] private ShapeSpawner _shapeSpawnerPrefab;
        [SerializeField] private CameraWrapper _cameraWrapper;
        [SerializeField] private VirtualCameraWrapper _virtualCameraWrapper;
        [SerializeField] private LevelConfig _levelConfig;
        [SerializeField] private CameraConfig _cameraConfig;

        private Tube _tube;
        private Player _player;
        private ShapeSpawner _shapeSpawner;
        private LevelCounter _levelCounter;
        private LevelDifficulty _levelDifficulty;

        private void Awake()
        {
            InitializeLevelCounter();
            InitializeLevelDifficulty();
            SetShapeAmountBasedOnTubeHeight();
            InitializeTube();
            InitializeShapeSpawner();
            InitializePlayer();
            InitializeCamera();
        }

        private void InitializeLevelDifficulty()
        {
            _levelDifficulty = new LevelDifficulty(_levelCounter);
        }

        private void InitializeLevelCounter()
        {
            _levelCounter = new LevelCounter();
            _levelCounter.Load();
            Debug.Log(_levelCounter.GetCurrent());
        }

        private void FixedUpdate()
        {
            _player.ApplyGravity();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                _player.FallDown();

            if (Input.GetKey(KeyCode.Space))
            {
                _levelCounter.Increment();
                Debug.Log(_levelCounter.GetCurrent());
                _levelCounter.Save();
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _levelCounter.Reset();
                Debug.Log(_levelCounter.GetCurrent());
            }
        }

        private void InitializeShapeSpawner()
        {
            _shapeSpawner = (ShapeSpawner) PrefabUtility.InstantiatePrefab(_shapeSpawnerPrefab);

            _shapeSpawner.Initialize(_levelConfig.ShapePrefabsProvider.GetRandomPrefabs());
            _shapeSpawner.ResizeShapesHeightTo(_levelConfig.ShapeConfig.Height);
            _shapeSpawner.ResizeShapesWidthTo(_levelConfig.TubeConfig.Size.Width * 0.7f);
            _shapeSpawner.SpawnShapes(_levelConfig.ShapeConfig, _tube.Rotator, _levelDifficulty);
        }

        private void SetShapeAmountBasedOnTubeHeight()
        {
            _levelConfig.ShapeConfig.Amount = Mathf.FloorToInt(
                _levelDifficulty.GetTubeHeightForCurrentDifficulty(_levelConfig.TubeConfig.Size.Height) * 0.75f /
                _levelConfig.ShapeConfig.Height * _levelConfig.ShapeConfig.Height);
        }

        private void InitializeTube()
        {
            _tube = (Tube) PrefabUtility.InstantiatePrefab(_tubePrefab);
            
            _tube.Initialize(_levelConfig.TubeConfig, _levelDifficulty);
            _tube.RotateAround();
        }

        private void InitializePlayer()
        {
            _player = (Player) PrefabUtility.InstantiatePrefab(_playerPrefab);

            const float yOffset = 4f;
            const float zOffset = 5f;

            var topShape = _tube.Rotator.GetChild(_tube.Rotator.childCount - 1);
            _player.transform.position = topShape.position + new Vector3(0, yOffset, zOffset);

            _player.Initialize(_levelConfig.PlayerConfig);
        }

        private void InitializeCamera()
        {
            _cameraConfig.InitTargetToFollow(_player.transform);
            _virtualCameraWrapper.Initialize(_cameraConfig);
            _cameraWrapper.Initialize(_cameraConfig);
        }
    }
}
