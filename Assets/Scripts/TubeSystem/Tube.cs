using StackFall.Shapes;
using UnityEngine;

namespace StackFall.TubeSystem
{
	[SelectionBase]
	public class Tube : MonoBehaviour
	{
		private TubeView _view;
		private FinishPlatform _finishPlatform;
		private TubeConfig _tubeConfig;

		public void Initialize(TubeConfig tubeConfig)
		{
			_tubeConfig = tubeConfig;
			
			_view = GetComponentInChildren<TubeView>();
			_finishPlatform = GetComponentInChildren<FinishPlatform>();
			
			// previous: _tubeConfig.Size.Width, _levelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeConfig.Size.Height)
			
			_view.SetLocalScale(_tubeConfig.Size);

			_finishPlatform.SetLocalScale(_tubeConfig.Size);
		}
	}
}