using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class ShapePartConfig
	{
		[field: SerializeField, FloatRangeSlider(50f, 550f)] public FloatRange FlyOffForce { get; private set; }
		[field: SerializeField, FloatRangeSlider(100f, 200f)] public FloatRange FlyOffTorque { get; private set; }
		[field: SerializeField, FloatRangeSlider(0f, 5f)] public FloatRange UpwardsModifier { get; private set; }
		[field: SerializeField] public ForceMode ExplosionForceMode { get; private set; }
	}
}