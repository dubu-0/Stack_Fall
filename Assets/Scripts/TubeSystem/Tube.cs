using StackFall.Shapes;
using UnityEngine;

namespace StackFall.TubeSystem
{
	[SelectionBase]
	public class Tube : MonoBehaviour
	{
		private FinishPlatform _finishPlatform;
		private TubeConfig _tubeConfig;
		private TubeView _view;

		public void Initialize(TubeConfig tubeConfig)
		{
			_tubeConfig = tubeConfig;

			_view = GetComponentInChildren<TubeView>();
			_finishPlatform = GetComponentInChildren<FinishPlatform>();

			// previous: _tubeConfig.Size.Width, _levelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeConfig.Size.Height)

			_view.SetLocalScale(_tubeConfig.InitialSize);

			_finishPlatform.SetLocalScale(_tubeConfig.InitialSize);
		}
	}
}