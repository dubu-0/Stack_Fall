using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct SpawnConfig
	{
		public Transform InitialSpawnPoint;
		public float Amount;
	}
}