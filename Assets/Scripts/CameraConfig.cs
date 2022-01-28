using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public struct CameraConfig
	{
		public Color Background;
		[Range(10, 30)] public int Size;
		public Transform TargetToFollow;
		public Vector3 PositionOffset;
		public Vector3 RotationOffset;
		
		public CameraClearFlags ClearFlags => CameraClearFlags.SolidColor;
		public bool IsOrthographic => true;
	}
}