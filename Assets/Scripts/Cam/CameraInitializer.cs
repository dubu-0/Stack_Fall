using System;
using UnityEngine;

namespace StackFall.Cam
{
	[Serializable]
	public class CameraInitializer
	{
		[SerializeField] private CameraWrapper _cameraWrapper;
		[SerializeField] private VirtualCameraWrapper _virtualCameraWrapper;
		[SerializeField] private CameraConfig _cameraConfig;

		public void Initialize(Transform followTarget)
		{
			_cameraConfig.InitTargetToFollow(followTarget);
			_virtualCameraWrapper.Initialize(_cameraConfig);
			_cameraWrapper.Initialize(_cameraConfig);
		}
	}
}