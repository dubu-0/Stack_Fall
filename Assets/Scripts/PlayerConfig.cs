using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct PlayerConfig
	{
		public Player Prefab;
		[Space]
		[Range(1, 12)] public float JumpPower;
		[Range(25, 50)] public float FallDownPower;
	}
}