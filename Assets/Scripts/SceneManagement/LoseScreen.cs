using UnityEngine;

namespace StackFall.SceneManagement
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private SceneLoader _sceneLoader;

        private void Start()
        {
            _sceneLoader.LoadGameScene();
        }
    }
}
