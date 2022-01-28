using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct PlayerConfig
	{
		[SerializeField] private Player _prefab;
		[Space]
		[Range(1, 12)] public float JumpPower;
		[Range(25, 150)] public float FallDownPower;

		public Player Prefab => _prefab;
	}
}