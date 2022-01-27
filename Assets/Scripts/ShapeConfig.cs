using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct ShapeConfig
	{
		public Shape Prefab;
		[Space]
		[Range(1, 7)] public float Height;
		[Range(10, 100)] public int Amount;
		[Range(1, 15)] public float RotationIndent;
		[Space]
		public Vector3 ExplosionOffset;
		[Range(20f, 400f)] public float ExplosionForce;
		[Range(5f, 150f)] public float ExplosionRadius;
		[Range(0f, 20f)] public float UpwardsModifier;
		public ForceMode ExplosionForceMode;
	}
}