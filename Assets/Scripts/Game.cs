using StackFall.Cam;
using StackFall.Fx;
using StackFall.LevelSystem;
using StackFall.ParticleSystems;
using StackFall.PlayerSystem;
using StackFall.Printers;
using StackFall.SceneManagement;
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
		[SerializeField] private GameUI _gameUI;

		private SpritePrinterController _spritePrinterController;

		private void Awake()
		{
			InitializeLevelSystem();
			InitializeTube(out var tubeHeight);
			InitializeShapeSpawner(out var shapeWidth);
			InitializePlayer(tubeHeight, shapeWidth);
			InitializeCamera();
			InitializeSpritePrinter();
			InitializeFxController();
			InitializeGameUI();
		}

		private void OnEnable()
		{
			_spritePrinterController.Subscribe();
			_playerSystemInitializer.PlayerEventController.Subscribe();
			_gameUI.Subscribe();
		}

		private void OnDisable()
		{
			_spritePrinterController.Unsubscribe();
			_playerSystemInitializer.PlayerEventController.Unsubscribe();
			_gameUI.Unsubscribe();
		}

		private void InitializeLevelSystem()
		{
			_levelSystemInitializer.Initialize();
		}

		private void InitializeTube(out int tubeHeight)
		{
			tubeHeight = _levelSystemInitializer.LevelDifficulty.GetTubeHeightForCurrentDifficulty(
				_tubeSystemInitializer
					.TubeConfig.InitialSize.Height);

			_tubeSystemInitializer.Initialize(tubeHeight);
		}

		private void InitializeShapeSpawner(out float shapeWidth)
		{
			var shapeTypes = _levelSystemInitializer.LevelDifficulty.GetShapeTypesForCurrentDifficulty();
			shapeWidth = _tubeSystemInitializer.TubeConfig.InitialSize.Width * 0.7f;
			var shapeAmount = Mathf.FloorToInt(_tubeSystemInitializer.TubeConfig.InitialSize.Height);
			var rotationSpeed =
				_levelSystemInitializer.LevelDifficulty.GetRotationSpeedForCurrentDifficulty(_shapeSpawnerInitializer
					.ShapeConfig.RotationSpeed);

			_shapeSpawnerInitializer.Initialize(shapeTypes, shapeWidth, shapeAmount, rotationSpeed);
		}

		private void InitializePlayer(int tubeHeight, float shapeWidth)
		{
			var spawnPosition = new Vector3(0, tubeHeight * 2, -shapeWidth * 1.2f);
			_playerSystemInitializer.PlayerConfig.InitSpawnPosition(spawnPosition);

			var sceneLoader = new SceneLoader();
			var particleSystemSpawner =
				new ParticleSystemSpawner(_playerSystemInitializer.PlayerConfig.PlayerTouchedGroundPrefab);
			_playerSystemInitializer.Initialize(sceneLoader, _levelSystemInitializer.LevelCounter,
				particleSystemSpawner);
		}

		private void InitializeCamera()
		{
			_cameraInitializer.Initialize(_playerSystemInitializer.Player.transform);
		}

		private void InitializeSpritePrinter()
		{
			_spritePrinterInitializer.Initialize();
		}

		private void InitializeFxController()
		{
			_spritePrinterController = new SpritePrinterController(_playerSystemInitializer.PlayerCollisionHandler,
				_spritePrinterInitializer.SpritePrinterPrefab);
		}

		private void InitializeGameUI()
		{
			_gameUI.Initialize(_levelSystemInitializer.LevelCounter, _playerSystemInitializer.PlayerCollisionHandler);
		}
	}
}