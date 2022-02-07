using System.Collections.Generic;
using UnityEngine;

namespace StackFall.Colors
{
	[CreateAssetMenu(menuName = "Collections/Create ColorCollection", fileName = "ColorCollection", order = 0)]
	public class ColorCollection : ScriptableObject
	{
		[SerializeField] private List<Color> _colors;

		private Color _previousRandom;

		public Color GetRandom()
		{
			var randomIndex = Random.Range(0, _colors.Count);
			_previousRandom = _colors[randomIndex];
			return _colors[randomIndex];
		}

		public Color GetPreviousRandom()
		{
			if (_previousRandom == default)
				_previousRandom = GetRandom();

			return _previousRandom;
		}
	}
}