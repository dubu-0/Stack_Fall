using System;
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
		public PlayerCollisionHandler PlayerCollisionHandler { get; private set; }

		public void Initialize(Vector3 spawnPosition)
		{
			InitializePlayer(spawnPosition);
			InitializePlayerCollisionHandler();
		}

		private void InitializePlayer(Vector3 position)
		{
			Player = (Player) PrefabUtility.InstantiatePrefab(_playerPrefab);

			Player.transform.position = position;
			Player.Initialize(_playerConfig);
		}

		private void InitializePlayerCollisionHandler()
		{
			PlayerCollisionHandler = Player.GetComponent<PlayerCollisionHandler>();
			PlayerCollisionHandler.Initialize();
		}
	}
}