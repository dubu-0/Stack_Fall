using System;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[Serializable]
	public class PlayerConfig
	{
		[field: SerializeField] public ParticleSystem PlayerTouchedGroundPrefab { get; private set; }
		[field: SerializeField] public ParticleSystem PlayerOnFirePrefab { get; private set; }
		[field: SerializeField] public PlayerBurnIndicator PlayerBurnIndicator { get; private set; }
		[field: SerializeField] public PlayerSound PlayerSound { get; private set; }

		[field: SerializeField]
		[field: Range(5, 80)]
		public float JumpPower { get; private set; }

		[field: SerializeField]
		[field: Range(1, 20)]
		public float GravityScale { get; private set; }

		[field: SerializeField]
		[field: Range(25, 250)]
		public float FallDownSpeed { get; private set; }

		[field: SerializeField]
		[field: Range(1, 8)]
		public float BurnDuration { get; private set; }

		[field: SerializeField]
		[field: Range(0.01f, 5)]
		public float BurnDelay { get; private set; }

		[field: SerializeField]
		[field: Range(0.05f, 1f)]
		public float BurnReduction { get; private set; }

		public Vector3 SpawnPosition { get; private set; }

		public void InitSpawnPosition(Vector3 position)
		{
			if (SpawnPosition != default)
				throw new Exception("Already inited");

			SpawnPosition = position;
		}
	}
}