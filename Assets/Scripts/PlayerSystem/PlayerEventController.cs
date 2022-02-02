using StackFall.LevelSystem;
using StackFall.ParticleSystems;
using StackFall.SceneManagement;

namespace StackFall.PlayerSystem
{
	public class PlayerEventController
	{
		private readonly PlayerCollisionHandler _playerCollisionHandler;
		private readonly SceneLoader _sceneLoader;
		private readonly LevelCounter _levelCounter;
		private readonly ParticleSystemSpawner _particleSystemSpawner;

		public PlayerEventController(PlayerCollisionHandler playerCollisionHandler, SceneLoader sceneLoader,
			LevelCounter levelCounter, ParticleSystemSpawner particleSystemSpawner)
		{
			_playerCollisionHandler = playerCollisionHandler;
			_sceneLoader = sceneLoader;
			_levelCounter = levelCounter;
			_particleSystemSpawner = particleSystemSpawner;
		}

		public void Subscribe()
		{
			_playerCollisionHandler.OnBlackPartTouched += _sceneLoader.ReloadScene;
			
			_playerCollisionHandler.OnWinPlatformTouched += _sceneLoader.ReloadScene;
			_playerCollisionHandler.OnWinPlatformTouched += _levelCounter.Increment;

			_playerCollisionHandler.OnShapePartTouched += _particleSystemSpawner.Spawn;
		}

		public void Unsubscribe()
		{
			_playerCollisionHandler.OnBlackPartTouched -= _sceneLoader.ReloadScene;
			
			_playerCollisionHandler.OnWinPlatformTouched -= _sceneLoader.ReloadScene;
			_playerCollisionHandler.OnWinPlatformTouched -= _levelCounter.Increment;
			
			_playerCollisionHandler.OnShapePartTouched -= _particleSystemSpawner.Spawn;
		}
	}
}