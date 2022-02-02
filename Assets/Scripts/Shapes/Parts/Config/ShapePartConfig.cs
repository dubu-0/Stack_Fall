using System;
using StackFall.Colors;
using StackFall.Ranges.Float;
using UnityEngine;

namespace StackFall.Shapes.Parts.Config
{
	[Serializable]
	public class ShapePartConfig
	{
		[SerializeField] private ColorCollection _colorCollection;
		[field: SerializeField, FloatRangeSlider(50f, 550f)] public FloatRange FlyOffForce { get; private set; }
		[field: SerializeField, FloatRangeSlider(100f, 200f)] public FloatRange FlyOffTorque { get; private set; }
		[field: SerializeField, FloatRangeSlider(0f, 5f)] public FloatRange UpwardsModifier { get; private set; }
		[field: SerializeField] public ForceMode ExplosionForceMode { get; private set; }

		private Color _color;
		
		public Color GetRandomColor()
		{
			if (_color == default)
				_color = _colorCollection.GetRandom();

			const float offset = 0.0005f;
			var colorWithOffset = new Color(_color.r + offset, _color.g + offset, _color.b + offset);
			
			return colorWithOffset;
		}
	}
}