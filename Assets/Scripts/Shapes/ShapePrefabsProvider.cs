using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StackFall.Shapes
{
	[Serializable]
	public class ShapePrefabsProvider
	{
		[SerializeField] private List<ShapePrefabsContainer> _allShapePrefabs;

		public List<Shape> GetRandomPrefabs()
		{
			var randomIndex = Random.Range(0, _allShapePrefabs.Count);
			return _allShapePrefabs[randomIndex].ShapePrefabs;
		}
	}
}