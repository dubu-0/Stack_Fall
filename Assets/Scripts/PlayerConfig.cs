using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class PlayerConfig
	{
		[field: SerializeField] public Player Prefab { get; private set; }
		[field: Space]
		[field: Range(1, 12)] public float JumpPower;
		[field: Range(25, 150)] public float FallDownSpeed;
	}
}