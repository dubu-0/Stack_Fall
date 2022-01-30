using UnityEngine;

namespace StackFall.Ranges.Float
{
	public class FloatRangeSliderAttribute : PropertyAttribute 
	{
		public readonly float Min;
		public readonly float Max;
		
		public FloatRangeSliderAttribute (float min, float max) 
		{
			Min = min;
			Max = max < min ? min : max;
		}
	}
}