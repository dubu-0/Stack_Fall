using System.Collections.Generic;
using UnityEngine;

namespace StackFall.Colors
{
	
	[CreateAssetMenu(menuName = "Collections/Create ColorCollection", fileName = "ColorCollection", order = 0)]
	public class ColorCollection : ScriptableObject
	{
		[SerializeField] private List<Color> _colors;

		public Color GetRandom()
		{
			var randomIndex = Random.Range(0, _colors.Count);
			return _colors[randomIndex];
		}
	}
}