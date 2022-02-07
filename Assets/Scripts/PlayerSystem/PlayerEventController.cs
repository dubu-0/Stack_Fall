using StackFall.LevelSystem;
using StackFall.ParticleSystems;
using StackFall.SceneManagement;

namespace StackFall.PlayerSystem
{
	public class PlayerEventController
	{
		private readonly LevelCounter _levelCounter;
		private readonly ParticleSystemSpawner _particleSystemSpawner;
		private readonly Player _player;
		private readonly PlayerBurnIndicator _playerBurnIndicator;
		private readonly PlayerCollisionHandler _playerCollisionHandler;
		private readonly PlayerSound _playerSound;

		private readonly SceneLoader _sceneLoader;

		public PlayerEventController(PlayerCollisionHandler playerCollisionHandler, Player player,
			SceneLoader sceneLoader, LevelCounter levelCounter, ParticleSystemSpawner particleSystemSpawner,
			PlayerBurnIndicator playerBurnIndicator, PlayerSound playerSound)
		{
			_playerCollisionHandler = playerCollisionHandler;
			_sceneLoader = sceneLoader;
			_levelCounter = levelCounter;
			_particleSystemSpawner = particleSystemSpawner;
			_playerBurnIndicator = playerBurnIndicator;
			_playerSound = playerSound;
			_player = player;
		}

		public void Subscribe()
		{
			_playerCollisionHandler.OnBlackPartTouched += _sceneLoader.ReloadScene;

			_playerCollisionHandler.OnWinPlatformTouched += _sceneLoader.ReloadScene;
			_playerCollisionHandler.OnWinPlatformTouched += _levelCounter.Increment;
			_playerCollisionHandler.OnWinPlatformTouched += _playerSound.PlayWinSound;

			_playerCollisionHandler.OnShapePartTouched += _particleSystemSpawner.Spawn;
			_playerCollisionHandler.OnShapePartTouched += _playerSound.PlayJumpSound;

			_player.OnFallingTimeChanged += _playerBurnIndicator.ChangeValue;

			_playerCollisionHandler.OnShapePartBroken += _playerSound.PlayBrokenSound;
		}

		public void Unsubscribe()
		{
			_playerCollisionHandler.OnBlackPartTouched -= _sceneLoader.ReloadScene;

			_playerCollisionHandler.OnWinPlatformTouched -= _sceneLoader.ReloadScene;
			_playerCollisionHandler.OnWinPlatformTouched -= _levelCounter.Increment;
			_playerCollisionHandler.OnWinPlatformTouched -= _playerSound.PlayWinSound;

			_playerCollisionHandler.OnShapePartTouched -= _particleSystemSpawner.Spawn;
			_playerCollisionHandler.OnShapePartTouched -= _playerSound.PlayJumpSound;

			_player.OnFallingTimeChanged -= _playerBurnIndicator.ChangeValue;

			_playerCollisionHandler.OnShapePartBroken -= _playerSound.PlayBrokenSound;
		}
	}
}