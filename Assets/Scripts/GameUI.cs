using System;
using StackFall.LevelSystem;
using StackFall.PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StackFall
{
	[Serializable]
	public class GameUI
	{
		[SerializeField] private TextMeshProUGUI _currentLevel;
		[SerializeField] private TextMeshProUGUI _nextLevel;
		[SerializeField] private Slider _levelProgressBar;
		private LevelCounter _levelCounter;

		private LevelUI _levelUI;

		public void Initialize(LevelCounter levelCounter, PlayerCollisionHandler playerCollisionHandler)
		{
			_levelCounter = levelCounter;
			_levelUI = new LevelUI(_levelCounter, _currentLevel, _nextLevel, playerCollisionHandler, _levelProgressBar);
		}

		public void Subscribe()
		{
			_levelUI.Subscribe();
		}

		public void Unsubscribe()
		{
			_levelUI.Unsubscribe();
		}
	}
}