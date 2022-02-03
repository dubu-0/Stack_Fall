using UnityEngine;

namespace StackFall.Cam
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
			_camera.orthographic = _cameraConfig.IsOrthographic;
			_camera.orthographicSize = _cameraConfig.Size;

			RenderSettings.skybox = _cameraConfig.Skybox;
		}
	}
}