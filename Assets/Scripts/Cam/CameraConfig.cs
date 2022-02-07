using System;
using StackFall.Skyboxes;
using UnityEngine;

namespace StackFall.Cam
{
	[Serializable]
	public class CameraConfig
	{
		[SerializeField] private SkyboxCollection _skyboxCollection;

		[field: SerializeField]
		[field: Range(10, 30)]
		public int Size { get; private set; }

		[field: SerializeField] public Vector3 PositionOffset { get; private set; }
		[field: SerializeField] public Vector3 RotationOffset { get; private set; }

		public Transform TargetToFollow { get; private set; }
		public CameraClearFlags ClearFlags => CameraClearFlags.Skybox;
		public bool IsOrthographic => false;
		public Material Skybox => _skyboxCollection.GetRandom();

		public void InitTargetToFollow(Transform targetToFollow)
		{
			if (TargetToFollow != null)
				throw new Exception("Already inited");

			TargetToFollow = targetToFollow;
		}
	}
}