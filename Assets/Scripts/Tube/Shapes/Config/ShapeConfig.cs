using System;
using StackFall.Ranges.Float;
using StackFall.Tube.Shapes.Parts.Config;
using UnityEngine;

namespace StackFall.Tube.Shapes.Config
{
	[Serializable]
	public class ShapeConfig
	{
		
		[field: SerializeField, Range(1, 7)] public float Height { get; private set; }
		[field: SerializeField, FloatRangeSlider(1f, 15f)] public FloatRange RotationIndent { get; private set; }
		[field: Space]
		[field: SerializeField] public ShapePartConfig ShapePartConfig { get; private set; }

		public int Amount { get; set; }
	}
}