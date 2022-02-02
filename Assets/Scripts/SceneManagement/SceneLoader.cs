using UnityEngine.SceneManagement;

namespace StackFall.SceneManagement
{
	public class SceneLoader
	{
		public void ReloadScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}