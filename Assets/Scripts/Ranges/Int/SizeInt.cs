using System;
using UnityEngine;

namespace StackFall.Ranges.Int
{
	[Serializable]
	public struct SizeInt
	{
		[Range(1, 15)] public int Width;
		[Range(1, 500)] public int Height;
	}
}