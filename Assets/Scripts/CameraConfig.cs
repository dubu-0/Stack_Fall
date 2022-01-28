﻿using System;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class CameraConfig
	{
		[field: SerializeField] public Color Background { get; private set; }
		[field: SerializeField, Range(10, 30)] public int Size { get; private set; }
		[field: SerializeField] public Vector3 PositionOffset { get; private set; }
		[field: SerializeField] public Vector3 RotationOffset { get; private set; }

		public Transform TargetToFollow { get; private set; }
		public CameraClearFlags ClearFlags => CameraClearFlags.SolidColor;
		public bool IsOrthographic => true;

		public void InitTargetToFollow(Transform targetToFollow)
		{
			if (TargetToFollow != null)
				throw new Exception("Already inited");

			TargetToFollow = targetToFollow;
		}
	}
}