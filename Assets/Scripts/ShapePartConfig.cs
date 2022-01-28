using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct ShapePartConfig
	{
		[FloatRangeSlider(50f, 550f)] public FloatRange FlyOffForce;
		[FloatRangeSlider(100f, 200f)] public FloatRange FlyOffTorque;
		[FloatRangeSlider(0f, 5f)] public FloatRange UpwardsModifier;
		public ForceMode ExplosionForceMode;
	}
}