using System;
using System.Collections.Generic;
using StackFall.Shapes.Config;
using UnityEditor;
using UnityEngine;

namespace StackFall.Shapes
{
	[Serializable]
	public class ShapeSpawnerInitializer
	{
		[SerializeField] private ShapeSpawner _shapeSpawnerPrefab;
		[SerializeField] private ShapeConfig _shapeConfig;

		public ShapeConfig ShapeConfig => _shapeConfig;

		public ShapeSpawner ShapeSpawner { get; private set; }

		public void Initialize(List<ShapeType> shapeTypes, float shapeWidth, int shapeAmount, float rotationSpeed)
		{
			_shapeConfig.InitAmount(shapeAmount);

			ShapeSpawner = (ShapeSpawner) PrefabUtility.InstantiatePrefab(_shapeSpawnerPrefab);

			ShapeSpawner.Initialize(_shapeConfig, shapeTypes);
			ShapeSpawner.ResizeShapesWidthTo(shapeWidth);
			ShapeSpawner.SpawnShapes();

			ShapeSpawner.StartEndlessRotating(rotationSpeed);
		}
	}
}