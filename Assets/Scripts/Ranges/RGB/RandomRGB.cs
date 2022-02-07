using System;
using StackFall.Ranges.Float;
using UnityEngine;

namespace StackFall.Ranges.RGB
{
	[Serializable]
	public struct RandomRGB
	{
		[SerializeField] [FloatRangeSlider(0, 1)]
		private FloatRange _r;

		[SerializeField] [FloatRangeSlider(0, 1)]
		private FloatRange _g;

		[SerializeField] [FloatRangeSlider(0, 1)]
		private FloatRange _b;

		[SerializeField] [FloatRangeSlider(0, 1)]
		private FloatRange _a;

		public Color GetRandom()
		{
			return new Color(_r.GetRandom, _g.GetRandom, _b.GetRandom, _a.GetRandom);
		}
	}
}