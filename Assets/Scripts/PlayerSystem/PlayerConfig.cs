using System;
using UnityEngine;

namespace StackFall.PlayerSystem
{
	[Serializable]
	public class PlayerConfig
	{
		[field: SerializeField] public ParticleSystem ParticleSystemPrefab { get; private set; }
		[field: SerializeField, Range(5, 80)] public float JumpPower { get; private set; }
		[field: SerializeField, Range(1, 20)] public float GravityScale { get; private set; }
		[field: SerializeField, Range(25, 150)] public float FallDownSpeed { get; private set; }

		public Vector3 SpawnPosition { get; private set; }

		public void InitSpawnPosition(Vector3 position)
		{
			if (SpawnPosition != default)
				throw new Exception("Already inited");

			SpawnPosition = position;
		}
	}
}