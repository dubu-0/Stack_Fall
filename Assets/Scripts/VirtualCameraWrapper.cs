using Cinemachine;
using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(CinemachineVirtualCamera))]
	public class VirtualCameraWrapper : MonoBehaviour
	{
		private CinemachineVirtualCamera _cinemachineVirtualCamera;

		public void Initialize(CameraConfig cameraConfig)
		{
			_cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
			_cinemachineVirtualCamera.Follow = cameraConfig.TargetToFollow;
		}
	}
}