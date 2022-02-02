using System;
using StackFall.LevelSystem;
using StackFall.ParticleSystems;
using StackFall.SceneManagement;
using UnityEditor;
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

		public void Initialize(SceneLoader sceneLoader, LevelCounter levelCounter,
			ParticleSystemSpawner particleSystemSpawner)
		{
			InitializePlayer();
			InitializePlayerCollisionHandler();
			InitializePlayerEventController(sceneLoader, levelCounter, particleSystemSpawner);
		}

		private void InitializePlayer()
		{
			Player = (Player) PrefabUtility.InstantiatePrefab(_playerPrefab);

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
			PlayerEventController = new PlayerEventController(PlayerCollisionHandler, sceneLoader, levelCounter,
				particleSystemSpawner);
		}
	}
}