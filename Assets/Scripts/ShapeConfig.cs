using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct ShapeConfig
	{
		[SerializeField] private Shape _prefab;
		[Space]
		[Range(1, 7)] public float Height;
		[Range(10, 100)] public int Amount;
		[Range(1, 15)] public float RotationIndent;
		[Space]
		public ShapePartConfig ShapePartConfig;

		public Shape Prefab => _prefab;
	}
}