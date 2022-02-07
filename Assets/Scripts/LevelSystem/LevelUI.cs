using StackFall.PlayerSystem;
using TMPro;
using UnityEngine.UI;

namespace StackFall.LevelSystem
{
	public class LevelUI
	{
		private readonly TextMeshProUGUI _currentLevel;
		private readonly LevelCounter _levelCounter;
		private readonly Slider _levelProgression;
		private readonly TextMeshProUGUI _nextLevel;
		private readonly PlayerCollisionHandler _playerCollisionHandler;

		public LevelUI(LevelCounter levelCounter, TextMeshProUGUI currentLevel, TextMeshProUGUI nextLevel,
			PlayerCollisionHandler playerCollisionHandler, Slider levelProgression)
		{
			_levelCounter = levelCounter;
			_playerCollisionHandler = playerCollisionHandler;

			_currentLevel = currentLevel;
			_nextLevel = nextLevel;
			_levelProgression = levelProgression;

			_currentLevel.text = _levelCounter.GetCurrent().ToString();
			_nextLevel.text = (_levelCounter.GetCurrent() + 1).ToString();
		}

		public void Subscribe()
		{
			_levelCounter.OnLevelChanged += UpdateCurrentLevel;
			_levelCounter.OnLevelChanged += UpdateNextLevel;
			_playerCollisionHandler.OnShapePartBroken += UpdateLevelProgression;
		}

		public void Unsubscribe()
		{
			_levelCounter.OnLevelChanged -= UpdateCurrentLevel;
			_levelCounter.OnLevelChanged -= UpdateNextLevel;
			_playerCollisionHandler.OnShapePartBroken -= UpdateLevelProgression;
		}

		private void UpdateCurrentLevel(int current)
		{
			_currentLevel.text = current.ToString();
		}

		private void UpdateNextLevel(int current)
		{
			_nextLevel.text = (current + 1).ToString();
		}

		private void UpdateLevelProgression(float value)
		{
			_levelProgression.value = value;
		}
	}
}