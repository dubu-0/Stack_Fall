using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct SizeInt
	{
		[Range(1, 15)] public int Width;
		[Range(1, 150)] public int Height;
	}
}