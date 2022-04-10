using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace StackFall.TubeSystem
{
	[Serializable]
	public class TubeSystemInitializer
	{
		[SerializeField] private Tube _tubePrefab;
		[SerializeField] private TubeConfig _tubeConfig;

		private Tube _tube;

		public TubeConfig TubeConfig => _tubeConfig;

		public void Initialize(int height)
		{
			_tube = Object.Instantiate(_tubePrefab);
			_tubeConfig.InitHeight(height);
			_tube.Initialize(_tubeConfig);
		}
	}
}