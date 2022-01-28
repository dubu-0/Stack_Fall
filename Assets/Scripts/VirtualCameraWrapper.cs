using Cinemachine;
using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(CinemachineVirtualCamera))]
	public class VirtualCameraWrapper : MonoBehaviour
	{
		private CinemachineVirtualCamera _cinemachineVirtualCamera;

		private CameraConfig _cameraConfig;
		
		public void Initialize(CameraConfig cameraConfig)
		{
			_cameraConfig = cameraConfig;
			_cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
			
			_cinemachineVirtualCamera.Follow = _cameraConfig.TargetToFollow;
			_cinemachineVirtualCamera.transform.position = _cameraConfig.TargetToFollow.position + _cameraConfig.PositionOffset;
			_cinemachineVirtualCamera.transform.rotation =
				Quaternion.Euler(_cameraConfig.TargetToFollow.rotation.eulerAngles + _cameraConfig.RotationOffset);
		}
	}
}