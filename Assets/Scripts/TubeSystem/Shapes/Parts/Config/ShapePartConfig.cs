using System;
using StackFall.Ranges.Float;
using UnityEngine;

namespace StackFall.TubeSystem.Shapes.Parts.Config
{
	[Serializable]
	public class ShapePartConfig
	{
		[SerializeField] private ColorCollection _colorCollection;
		[field: SerializeField, FloatRangeSlider(50f, 550f)] public FloatRange FlyOffForce { get; private set; }
		[field: SerializeField, FloatRangeSlider(100f, 200f)] public FloatRange FlyOffTorque { get; private set; }
		[field: SerializeField, FloatRangeSlider(0f, 5f)] public FloatRange UpwardsModifier { get; private set; }
		[field: SerializeField] public ForceMode ExplosionForceMode { get; private set; }

		private static Color _sharedColor;
		
		public Color GetRandomColor()
		{
			if (_sharedColor == default)
				_sharedColor = _colorCollection.GetRandom();

			return _sharedColor;
		}
	}
}