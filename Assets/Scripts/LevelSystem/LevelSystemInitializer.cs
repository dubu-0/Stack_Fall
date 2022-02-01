using System;
using UnityEngine;

namespace StackFall.LevelSystem
{
	[Serializable]
	public class LevelSystemInitializer
	{
		private LevelCounter _levelCounter;

		public LevelDifficulty LevelDifficulty { get; private set; }

		public void Initialize()
		{
			InitializeLevelCounter();
			InitializeLevelDifficulty();
		}

		private void InitializeLevelCounter()
		{
			_levelCounter = new LevelCounter();
			_levelCounter.Load();
			Debug.Log(_levelCounter.GetCurrent());
		}

		private void InitializeLevelDifficulty()
		{
			LevelDifficulty = new LevelDifficulty(_levelCounter);
		}
	}
}