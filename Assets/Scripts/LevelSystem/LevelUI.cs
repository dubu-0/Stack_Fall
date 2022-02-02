using StackFall.PlayerSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace StackFall.LevelSystem
{
	public class LevelUI
	{
		private readonly LevelCounter _levelCounter;
		private readonly Player _player;
		private readonly TextMeshProUGUI _currentLevel;
		private readonly TextMeshProUGUI _nextLevel;
		private readonly Slider _slider;

		public LevelUI(LevelCounter levelCounter, TextMeshProUGUI currentLevel, TextMeshProUGUI nextLevel, Player player, Slider slider)
		{
			_levelCounter = levelCounter;
			_player = player;
			
			_currentLevel = currentLevel;
			_nextLevel = nextLevel;
			_slider = slider;

			_currentLevel.text = _levelCounter.GetCurrent().ToString();
			_nextLevel.text = (_levelCounter.GetCurrent() + 1).ToString();
		}

		public void Subscribe()
		{
			_levelCounter.OnLevelChanged += UpdateCurrentLevel;
			_levelCounter.OnLevelChanged += UpdateNextLevel;
			_player.OnStartFalling += UpdateSlider;
		}
		
		public void Unsubscribe()
		{
			_levelCounter.OnLevelChanged -= UpdateCurrentLevel;
			_levelCounter.OnLevelChanged -= UpdateNextLevel;
			_player.OnStartFalling -= UpdateSlider;
		}

		private void UpdateCurrentLevel(int current)
		{
			_currentLevel.text = current.ToString();
			Debug.Log($"{this}: {current}");
		}
		
		private void UpdateNextLevel(int current)
		{
			_nextLevel.text = (current + 1).ToString();
		}

		public void UpdateSlider(float value)
		{
			_slider.value = value;
		}
	}
}