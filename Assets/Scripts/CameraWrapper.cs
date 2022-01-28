using UnityEngine;

namespace StackFall
{
	[RequireComponent(typeof(Camera))]
	public class CameraWrapper : MonoBehaviour
	{
		private Camera _camera;
		private CameraConfig _cameraConfig;

		public void Initialize(CameraConfig cameraConfig)
		{
			_cameraConfig = cameraConfig;
			
			_camera = GetComponent<Camera>();
			
			_camera.clearFlags = _cameraConfig.ClearFlags;
			_camera.backgroundColor = _cameraConfig.Background;
			_camera.orthographic = _cameraConfig.IsOrthographic;
			_camera.orthographicSize = _cameraConfig.Size;
			_camera.transform.position = _cameraConfig.TargetToFollow.position + _cameraConfig.PositionOffset;
			_camera.transform.rotation =
				Quaternion.Euler(_cameraConfig.TargetToFollow.rotation.eulerAngles + _cameraConfig.RotationOffset);
		}
	}
}