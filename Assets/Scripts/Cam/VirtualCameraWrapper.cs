using Cinemachine;
using UnityEngine;

namespace StackFall.Cam
{
	[RequireComponent(typeof(CinemachineVirtualCamera))]
	public class VirtualCameraWrapper : MonoBehaviour
	{
		private CameraConfig _cameraConfig;
		private CinemachineVirtualCamera _cinemachineVirtualCamera;

		public void Initialize(CameraConfig cameraConfig)
		{
			_cameraConfig = cameraConfig;
			_cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

			_cinemachineVirtualCamera.Follow = _cameraConfig.TargetToFollow;
			_cinemachineVirtualCamera.transform.position =
				_cameraConfig.TargetToFollow.position + _cameraConfig.PositionOffset;
			_cinemachineVirtualCamera.transform.rotation =
				Quaternion.Euler(_cameraConfig.TargetToFollow.rotation.eulerAngles + _cameraConfig.RotationOffset);
		}
	}
}