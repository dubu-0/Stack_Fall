using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class TubeConfig
	{
		[SerializeField] private Tube _prefab;
		[field: Space] 
		[field: SerializeField] public SizeInt Size { get; private set; }
		[Range(10f, 200f)] public float RotationSpeed;

		public Tube Prefab => _prefab;
	}
}