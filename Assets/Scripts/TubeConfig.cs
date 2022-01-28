using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct TubeConfig
	{
		[SerializeField] private Tube _prefab;
		[Space]
		public SizeInt Size;
		[Range(10f, 200f)] public float RotationSpeed;

		public Tube Prefab => _prefab;
	}
}