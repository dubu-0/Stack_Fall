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

		public Player PlayerPrefab { get; private set; }
		public PlayerConfig PlayerConfig => _playerConfig;
		public PlayerCollisionHandler PlayerCollisionHandler { get; private set; }
		public PlayerEventController PlayerEventController { get; private set; }

		public void Initialize(Vector3 spawnPosition, SceneLoader sceneLoader, LevelCounter levelCounter,
			ParticleSystemSpawner particleSystemSpawner)
		{
			InitializePlayer(spawnPosition);
			InitializePlayerCollisionHandler();
			InitializePlayerEventController(sceneLoader, levelCounter, particleSystemSpawner);
		}

		private void InitializePlayer(Vector3 position)
		{
			PlayerPrefab = (Player) PrefabUtility.InstantiatePrefab(_playerPrefab);

			PlayerPrefab.transform.position = position;
			PlayerPrefab.Initialize(_playerConfig);
		}

		private void InitializePlayerCollisionHandler()
		{
			PlayerCollisionHandler = PlayerPrefab.GetComponent<PlayerCollisionHandler>();
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