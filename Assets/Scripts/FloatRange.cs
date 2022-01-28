using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct FloatRange
	{
		// Used in property drawer, DO NOT rename, or rename in drawer too
		[SerializeField] private float _min;
		[SerializeField] private float _max;

		public float GetRandom => UnityEngine.Random.Range(_min, _max);
	}
}