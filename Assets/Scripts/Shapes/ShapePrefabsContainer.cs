using System;
using System.Collections.Generic;
using UnityEngine;

namespace StackFall.Shapes
{
	[Serializable]
	public class ShapePrefabsContainer
	{
		[SerializeField] private List<Shape> _shapePrefabs;

		public List<Shape> ShapePrefabs => _shapePrefabs;
	}
}