using System.Collections.Generic;
using UnityEngine;

namespace StackFall.Skyboxes
{
	[CreateAssetMenu(menuName = "Collections/Create SkyboxCollection", fileName = "SkyboxCollection", order = 0)]
	public class SkyboxCollection : ScriptableObject
	{
		[SerializeField] private List<Material> _skyboxes;

		private Material _previousRandom;

		public Material GetRandom()
		{
			var randomIndex = Random.Range(0, _skyboxes.Count);
			_previousRandom = _skyboxes[randomIndex];
			return _skyboxes[randomIndex];
		}

		public Material GetPreviousRandom()
		{
			if (_previousRandom == default)
				_previousRandom = GetRandom();

			return _previousRandom;
		}
	}
}