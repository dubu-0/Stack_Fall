﻿using System;
using System.Collections.Generic;
using StackFall.Tube.Shapes;
using UnityEngine;

namespace StackFall
{
	[Serializable]
	public class ShapePrefabsContainer
	{
		[SerializeField] private List<Shape> _shapePrefabs;

		public List<Shape> ShapePrefabs => _shapePrefabs;
	}
}