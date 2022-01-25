using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct SizeInt
	{
		[Range(1, 100)] public int Width;
		[Range(1, 100)] public int Height;
	}
}