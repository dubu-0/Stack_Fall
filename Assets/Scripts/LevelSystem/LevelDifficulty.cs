using System.Collections.Generic;
using StackFall.TubeSystem.Shapes.Config;
using UnityEngine;

namespace StackFall.LevelSystem
{
	public class LevelDifficulty
	{
		private readonly List<int> _levels = new List<int> { 20, 50, 100, 200, int.MaxValue };
		private readonly LevelCounter _levelCounter;

		private readonly int _current;
		
		public LevelDifficulty(LevelCounter levelCounter)
		{
			_levelCounter = levelCounter;
			_current = GetCurrent();
		}

		public List<ShapeType> GetShapeTypesForCurrentDifficulty()
		{
			var shapeTypes = new List<ShapeType>(3);

			if (_current == 1)
			{
				shapeTypes.Add(ShapeType.ZeroBlackParts);
				shapeTypes.Add(ShapeType.OneBlackPart);
			}
			else if (_current == 2)
			{
				shapeTypes.Add(ShapeType.ZeroBlackParts);
				shapeTypes.Add(ShapeType.OneBlackPart);
				shapeTypes.Add(ShapeType.TwoBlackParts);
			}
			else if (_current == 3)
			{
				shapeTypes.Add(ShapeType.OneBlackPart);
				shapeTypes.Add(ShapeType.TwoBlackParts);
			}
			else if (_current == 4)
			{
				shapeTypes.Add(ShapeType.TwoBlackParts);
				shapeTypes.Add(ShapeType.ThreeBlackParts);
			}
			else if (_current == 5)
			{
				shapeTypes.Add(ShapeType.ThreeBlackParts);
			}

			return shapeTypes;
		}

		public float GetRotationSpeedForCurrentDifficulty(float minRotationSpeed)
		{
			return minRotationSpeed + ScaledSquareRoot(_levelCounter.GetCurrent(), 18);
		}
		
		public float GetTubeHeightForCurrentDifficulty(float minTubeHeight)
		{
			return minTubeHeight + ScaledSquareRoot(_levelCounter.GetCurrent(), 18);
		}

		private int GetCurrent()
		{
			for (var i = 0; i < _levels.Count; i++)
			{
				if (_levels[i] >= _levelCounter.GetCurrent())
					return i + 1;
			}

			return 0;
		}

		private float ScaledSquareRoot(float value, float scale)
		{
			return scale * Mathf.Sqrt(value);
		}
	}
}