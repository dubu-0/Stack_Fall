using System;
using UnityEngine;

namespace StackFall.LevelSystem
{
	public class LevelCounter
	{
		private const string Key = nameof(_current);
		private int _current = 1;

		public event Action<int> OnLevelChanged;

		public int GetCurrent()
		{
			return _current;
		}

		public void Increment()
		{
			_current++;
			OnLevelChanged?.Invoke(_current);
			Save();
		}

		public void Reset()
		{
			_current = 1;
			OnLevelChanged?.Invoke(_current);
			Save();
		}

		public void Save()
		{
			PlayerPrefs.SetInt(Key, _current);
			PlayerPrefs.Save();
		}

		public void Load()
		{
			_current = PlayerPrefs.GetInt(Key, _current);
			OnLevelChanged?.Invoke(_current);
		}
	}
}