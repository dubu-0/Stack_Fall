using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct TubeConfig
	{
		public Tube Prefab;
		[Space]
		public SizeInt Size;
		[Range(10f, 200f)] public float RotationSpeed;
	}
}