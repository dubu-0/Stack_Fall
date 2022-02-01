using System;
using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.TubeSystem
{
	[Serializable]
	public class TubeConfig
	{
		[field: SerializeField] public SizeInt Size { get; private set; }

		public void InitHeight(int height)
		{
			var size = Size;
			size.Height = height;
			Size = size;
		}
	}
}