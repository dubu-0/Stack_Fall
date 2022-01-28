using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class ShapeConfig
	{
		[field: SerializeField] public Shape Prefab { get; private set; }
		[field: Space]
		[field: SerializeField, Range(1, 7)] public float Height { get; private set; }
		[field: SerializeField, Range(1, 15)] public float RotationIndent { get; private set; }
		[field: Space]
		[field: SerializeField] public ShapePartConfig ShapePartConfig { get; private set; }

		public int Amount { get; private set; }

		public void InitAmount(int value)
		{
			if (Amount != 0)
				throw new Exception("Amount already inited");

			Amount = value;
		}
	}
}