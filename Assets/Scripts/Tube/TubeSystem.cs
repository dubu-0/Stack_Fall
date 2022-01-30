using System.Collections;
using DG.Tweening;
using StackFall.Tube.Shapes;
using UnityEngine;

namespace StackFall.Tube
{
	[SelectionBase]
	public class TubeSystem : MonoBehaviour
	{
		[field: SerializeField] public Transform Rotator { get; private set; }
		
		private TubeView _view;
		private FinishPlatform _finishPlatform;
		private TubeConfig _tubeConfig;
		private LevelDifficulty _levelDifficulty;

		public void Initialize(TubeConfig tubeConfig, LevelDifficulty levelDifficulty)
		{
			_tubeConfig = tubeConfig;
			_levelDifficulty = levelDifficulty;
			
			_view = GetComponentInChildren<TubeView>();
			_finishPlatform = GetComponentInChildren<FinishPlatform>();
			
			_view.SetLocalScale(_tubeConfig.Size.Width, _levelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeConfig.Size.Height));

			_finishPlatform.SetLocalScale(_tubeConfig.Size);
		}

		public void RotateAround()
		{
			StartCoroutine(EndlessRotating());
		}

		private IEnumerator EndlessRotating()
		{
			while (true)
			{
				var rotation = new Vector3(0, _levelDifficulty.GetRotationSpeedForCurrentDifficulty(_tubeConfig.RotationSpeed) * Time.deltaTime, 0);
				Rotator.transform.Rotate(rotation);
				yield return null;
			}
		}
	}
}