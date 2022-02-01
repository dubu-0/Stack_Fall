using StackFall.Cam;
using StackFall.Fx;
using StackFall.LevelSystem;
using StackFall.PlayerSystem;
using StackFall.Printers;
using StackFall.Shapes;
using StackFall.TubeSystem;
using UnityEngine;

namespace StackFall
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private LevelSystemInitializer _levelSystemInitializer;
        [SerializeField] private ShapeSpawnerInitializer _shapeSpawnerInitializer;
        [SerializeField] private TubeSystemInitializer _tubeSystemInitializer;
        [SerializeField] private PlayerSystemInitializer _playerSystemInitializer;
        [SerializeField] private CameraInitializer _cameraInitializer;
        [SerializeField] private SpritePrinterInitializer _spritePrinterInitializer;
        [SerializeField] private FxInitializer _fxInitializer;

        private void Awake()
        {
            _levelSystemInitializer.Initialize();

            _shapeSpawnerInitializer.Initialize(
                _levelSystemInitializer.LevelDifficulty.GetShapeTypesForCurrentDifficulty(),
                _tubeSystemInitializer.TubeConfig.Size.Width * 0.7f,
                Mathf.FloorToInt(
                    _levelSystemInitializer.LevelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeSystemInitializer
                        .TubeConfig.Size.Height) * 0.75f / _shapeSpawnerInitializer.ShapeConfig.Height *
                    _shapeSpawnerInitializer.ShapeConfig.Height));

            _tubeSystemInitializer.Initialize(
                _levelSystemInitializer.LevelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeSystemInitializer
                    .TubeConfig.Size.Height));
            
            _playerSystemInitializer.Initialize(new Vector3(0, _tubeSystemInitializer.TubeConfig.Size.Height * 2, -4.85f));
            
            _cameraInitializer.Initialize(_playerSystemInitializer.Player.transform);
            
            _spritePrinterInitializer.Initialize();
            
            _fxInitializer.Initialize(_playerSystemInitializer.PlayerCollisionHandler, _spritePrinterInitializer.SpritePrinterPrefab);
        }

        private void OnEnable()
        {
            _fxInitializer.FXController.Subscribe();
        }

        private void OnDisable()
        {
            _fxInitializer.FXController.Unsubscribe();
        }
    }
}
