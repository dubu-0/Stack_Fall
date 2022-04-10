using System;
using StackFall.LevelSystem;
using StackFall.ParticleSystems;
using StackFall.SceneManagement;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[Serializable]
	public class PlayerSystemInitializer
	{
		[SerializeField] private Player _playerPrefab;
		[SerializeField] private PlayerConfig _playerConfig;

		public Player Player { get; private set; }
		public PlayerConfig PlayerConfig => _playerConfig;
		public PlayerCollisionHandler PlayerCollisionHandler { get; private set; }
		public PlayerEventController PlayerEventController { get; private set; }

		public void Initialize(LevelCounter levelCounter,
			ParticleSystemSpawner particleSystemSpawner)
		{
			InitializePlayer();
			InitializePlayerCollisionHandler();
			InitializePlayerEventController(_playerConfig.SceneLoader, levelCounter, particleSystemSpawner);
		}

		private void InitializePlayer()
		{
			Player = UnityEngine.Object.Instantiate(_playerPrefab);
			UnityEngine.Object.Instantiate(PlayerConfig.PlayerOnFirePrefab, Player.transform);
			Player.transform.position = _playerConfig.SpawnPosition;
			Player.Initialize(_playerConfig);
		}

		private void InitializePlayerCollisionHandler()
		{
			PlayerCollisionHandler = Player.GetComponent<PlayerCollisionHandler>();
			PlayerCollisionHandler.Initialize();
		}

		private void InitializePlayerEventController(SceneLoader sceneLoader, LevelCounter levelCounter,
			ParticleSystemSpawner particleSystemSpawner)
		{
			_playerConfig.PlayerSound.Initialize(Player.GetComponent<AudioSource>());

			PlayerEventController = new PlayerEventController(PlayerCollisionHandler, Player, sceneLoader, levelCounter,
				particleSystemSpawner, _playerConfig.PlayerBurnIndicator, _playerConfig.PlayerSound);
		}
	}
}