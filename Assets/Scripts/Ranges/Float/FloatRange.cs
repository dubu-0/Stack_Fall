using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StackFall.Ranges.Float
{
	[Serializable]
	public struct FloatRange
	{
		// Used in property drawer, DO NOT rename, or rename in drawer too
		[SerializeField] private float _min;
		[SerializeField] private float _max;

		public float GetRandom => Random.Range(_min, _max);
	}
}