using System;
using System.Collections.Generic;
using StackFall.Ranges.Float;
using StackFall.Shapes.Parts.Config;
using UnityEngine;

namespace StackFall.Shapes.Config
{
	[Serializable]
	public class ShapeConfig
	{
		[SerializeField] private ShapePrefabsProvider _shapePrefabsProvider;

		[field: SerializeField]
		[field: Range(10f, 500f)]
		public float RotationSpeed { get; private set; }

		[field: SerializeField]
		[field: FloatRangeSlider(1f, 15f)]
		public FloatRange RotationIndent { get; private set; }

		[field: Space] [field: SerializeField] public ShapePartConfig ShapePartConfig { get; private set; }

		public List<Shape> GetRandomShapePrefabs => _shapePrefabsProvider.GetRandomPrefabs();
		public int Amount { get; private set; }
		public float Height { get; set; }

		public void InitAmount(int value)
		{
			if (Amount != 0)
				throw new Exception("Already inited");

			Amount = value;
		}
	}
}