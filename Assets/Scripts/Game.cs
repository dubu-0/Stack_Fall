using UnityEditor;
using UnityEngine;

namespace StackFall
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private TubeConfig _tubeConfig;
        [Space]
        [SerializeField] private ShapeConfig _shapeConfig;
        [Space] 
        [SerializeField] private PlayerConfig _playerConfig;
        [Space]
        [SerializeField] private CameraWrapper _cameraWrapper;
        [SerializeField] private VirtualCameraWrapper _virtualCameraWrapper;
        [SerializeField] private CameraConfig _cameraConfig;

        private Tube _tube;
        private Player _player;

        private void OnValidate()
        {
            if (_tube)
            {
                _tube.Initialize(_tubeConfig);
                _tube.ResizeShapes(_shapeConfig);
                _tube.ReInitializeShapes(_shapeConfig);
            }
        }

        private void Awake()
        {
            SetShapeAmountBasedOnTubeHeight();
            InitializeTube();
            InitializePlayer();
            InitializeCamera();
        }

        private void Update()
        {
            if (_player.CanJump()) 
                _player.Jump();

            if (Input.GetMouseButton(0))
                _player.FallDown();
        }

        private void SetShapeAmountBasedOnTubeHeight()
        {
            _shapeConfig.Amount =
                Mathf.FloorToInt(_tubeConfig.Size.Height * 0.75f / _shapeConfig.Height * _shapeConfig.Height);
        }

        private void InitializeTube()
        {
            _tube = (Tube) PrefabUtility.InstantiatePrefab(_tubeConfig.Prefab);
            
            _tube.Initialize(_tubeConfig);
            _tube.SpawnShapes(_shapeConfig);
            _tube.ResizeShapes(_shapeConfig);
            _tube.RotateAround();
        }

        private void InitializePlayer()
        {
            _player = (Player) PrefabUtility.InstantiatePrefab(_playerConfig.Prefab);

            const float zOffset = 8f;
            const float yOffset = -5f;
            var playerPosition = _player.transform.position;
            playerPosition.x = _tube.transform.position.x;
            playerPosition.y = _tubeConfig.Size.Height * 2 + yOffset;
            playerPosition.z = _tube.transform.position.z + zOffset;
            _player.transform.position = playerPosition;
            
            _player.Initialize(_playerConfig);
        }

        private void InitializeCamera()
        {
            _cameraConfig.TargetToFollow = _player.transform;
            _cameraWrapper.Initialize(_cameraConfig);
            _virtualCameraWrapper.Initialize(_cameraConfig);
        }
    }
}
