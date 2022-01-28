using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class Game : MonoBehaviour
    {
        [SerializeField, Space] private LevelConfig _levelConfig;
        [SerializeField] private CameraWrapper _cameraWrapper;
        [SerializeField] private VirtualCameraWrapper _virtualCameraWrapper;
        [SerializeField] private CameraConfig _cameraConfig;

        private Tube _tube;
        private Player _player;

        private void OnValidate()
        {
            if (_tube)
            {
                _tube.Initialize(_levelConfig.TubeConfig);
                _tube.ResizeShapes(_levelConfig.ShapeConfig);
                _tube.ReInitializeShapes(_levelConfig.ShapeConfig);
            }
        }

        private void Awake()
        {
            SetShapeAmountBasedOnTubeHeight();
            InitializeTube();
            InitializePlayer();
            InitializeCamera();
        }

        private void FixedUpdate()
        {
            if (_player.CanJump()) 
                _player.Jump();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
                _player.FallDown();
        }

        private void SetShapeAmountBasedOnTubeHeight()
        {
            _levelConfig.ShapeConfig.InitAmount(Mathf.FloorToInt(_levelConfig.TubeConfig.Size.Height * 0.75f /
                _levelConfig.ShapeConfig.Height * _levelConfig.ShapeConfig.Height));
        }

        private void InitializeTube()
        {
            _tube = (Tube) PrefabUtility.InstantiatePrefab(_levelConfig.TubeConfig.Prefab);
            
            _tube.Initialize(_levelConfig.TubeConfig);
            _tube.SpawnShapes(_levelConfig.ShapeConfig);
            _tube.ResizeShapes(_levelConfig.ShapeConfig);
            _tube.RotateAround();
        }

        private void InitializePlayer()
        {
            _player = (Player) PrefabUtility.InstantiatePrefab(_levelConfig.PlayerConfig.Prefab);

            const float zOffset = 6f;
            const float yOffset = -5f;
            var playerPosition = _player.transform.position;
            playerPosition.x = _tube.transform.position.x;
            playerPosition.y = _levelConfig.TubeConfig.Size.Height * 2 + yOffset;
            playerPosition.z = _tube.transform.position.z + zOffset;
            _player.transform.position = playerPosition;
            
            _player.Initialize(_levelConfig.PlayerConfig);
        }

        private void InitializeCamera()
        {
            _cameraConfig.InitTargetToFollow(_player.transform);
            _cameraWrapper.Initialize(_cameraConfig);
            _virtualCameraWrapper.Initialize(_cameraConfig);
        }
    }
}
