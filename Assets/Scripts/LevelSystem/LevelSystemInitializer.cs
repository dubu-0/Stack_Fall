using System;
using UnityEngine;

namespace StackFall.LevelSystem
{
	[Serializable]
	public class LevelSystemInitializer
	{
		public LevelDifficulty LevelDifficulty { get; private set; }
		public LevelCounter LevelCounter { get; private set; }
		
		public void Initialize()
		{
			InitializeLevelCounter();
			InitializeLevelDifficulty();
		}

		private void InitializeLevelCounter()
		{
			LevelCounter = new LevelCounter();
			LevelCounter.Load();
		}

		private void InitializeLevelDifficulty()
		{
			LevelDifficulty = new LevelDifficulty(LevelCounter);
		}
	}
}