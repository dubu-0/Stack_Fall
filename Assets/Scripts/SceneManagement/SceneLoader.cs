using UnityEngine;
using UnityEngine.SceneManagement;

namespace StackFall.SceneManagement
{
	[CreateAssetMenu(menuName = "Scene Management/Create SceneLoader", fileName = "SceneLoader", order = 0)]
	public class SceneLoader : ScriptableObject
	{
		[SerializeField] private string _menuSceneName = "Main Menu";
		[SerializeField] private string _winScreenName = "Win Screen";
		[SerializeField] private string _loseScreenName = "Lose Screen";
		[SerializeField] private string _gameSceneName = "Game";
		
		private AsyncOperation _gameSceneLoadOperation;

		public void ActivateGameScene()
		{
			_gameSceneLoadOperation.allowSceneActivation = true;
		}

		public void LoadMainMenu()
		{
			SceneManager.LoadSceneAsync(_menuSceneName, LoadSceneMode.Single);
		}

		public void LoadWinScreen()
		{
			if (SceneManager.sceneCount > 1)
				return;

			SceneManager.LoadSceneAsync(_winScreenName, LoadSceneMode.Additive);
		}
		
		public void LoadLoseScreen()
		{
			if (SceneManager.sceneCount > 1)
				return;

			SceneManager.LoadSceneAsync(_loseScreenName, LoadSceneMode.Additive);
		}

		public void LoadGameScene()
		{
			_gameSceneLoadOperation = SceneManager.LoadSceneAsync(_gameSceneName, LoadSceneMode.Single);
			_gameSceneLoadOperation.allowSceneActivation = false;
		}
	}
}