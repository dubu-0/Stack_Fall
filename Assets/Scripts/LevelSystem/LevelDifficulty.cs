using System.Collections.Generic;
using StackFall.Shapes.Config;
using UnityEngine;

namespace StackFall.LevelSystem
{
	public class LevelDifficulty
	{
		private readonly List<int> _levels = new List<int> { 20, 50, 100, 200, int.MaxValue };
		private readonly LevelCounter _levelCounter;

		private readonly int _currentDifficulty;
		
		public LevelDifficulty(LevelCounter levelCounter)
		{
			_levelCounter = levelCounter;
			_currentDifficulty = GetCurrentDifficulty();
		}

		public List<ShapeType> GetShapeTypesForCurrentDifficulty()
		{
			var shapeTypes = new List<ShapeType>(3);

			switch (_currentDifficulty)
			{
				case 1:
					shapeTypes.Add(ShapeType.ZeroBlackParts);
					shapeTypes.Add(ShapeType.OneBlackPart);
					break;
				case 2:
					shapeTypes.Add(ShapeType.ZeroBlackParts);
					shapeTypes.Add(ShapeType.OneBlackPart);
					shapeTypes.Add(ShapeType.TwoBlackParts);
					break;
				case 3:
					shapeTypes.Add(ShapeType.OneBlackPart);
					shapeTypes.Add(ShapeType.TwoBlackParts);
					break;
				case 4:
					shapeTypes.Add(ShapeType.TwoBlackParts);
					shapeTypes.Add(ShapeType.ThreeBlackParts);
					break;
				case 5:
					shapeTypes.Add(ShapeType.ThreeBlackParts);
					break;
			}

			return shapeTypes;
		}

		public float GetRotationSpeedForCurrentDifficulty(float minRotationSpeed)
		{
			return minRotationSpeed + ScaledSquareRoot(_levelCounter.GetCurrent(), 18);
		}
		
		public int GetTubeHeightForCurrentDifficulty(int minTubeHeight)
		{
			return Mathf.RoundToInt(minTubeHeight + ScaledSquareRoot(_levelCounter.GetCurrent(), 18));
		}

		private int GetCurrentDifficulty()
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