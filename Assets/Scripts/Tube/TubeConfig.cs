using System;
using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.Tube
{
	[Serializable]
	public class TubeConfig
	{
		[field: SerializeField] public SizeInt Size { get; private set; }
		[field: SerializeField, Range(10f, 500f)] public float RotationSpeed { get; private set; }
	}
}