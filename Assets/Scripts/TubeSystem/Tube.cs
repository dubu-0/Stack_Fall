using StackFall.Shapes;
using UnityEngine;

namespace StackFall.TubeSystem
{
	[SelectionBase]
	public class Tube : MonoBehaviour
	{
		private WinPlatform _winPlatform;
		private TubeConfig _tubeConfig;
		private TubeView _view;

		public void Initialize(TubeConfig tubeConfig)
		{
			_tubeConfig = tubeConfig;

			_view = GetComponentInChildren<TubeView>();
			_winPlatform = GetComponentInChildren<WinPlatform>();

			// previous: _tubeConfig.Size.Width, _levelDifficulty.GetTubeHeightForCurrentDifficulty(_tubeConfig.Size.Height)

			_view.SetLocalScale(_tubeConfig.InitialSize);

			_winPlatform.SetLocalScale(_tubeConfig.InitialSize);
		}
	}
}