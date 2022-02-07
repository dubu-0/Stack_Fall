using System;
using StackFall.Ranges.Int;
using UnityEngine;

namespace StackFall.TubeSystem
{
	[Serializable]
	public class TubeConfig
	{
		[field: SerializeField] public SizeInt InitialSize { get; private set; }

		public void InitHeight(int height)
		{
			var size = InitialSize;
			size.Height = height;
			InitialSize = size;
		}
	}
}