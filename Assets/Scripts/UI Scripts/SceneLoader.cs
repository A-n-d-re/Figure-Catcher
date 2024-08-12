using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartGame()
    {
        int _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(_currentSceneIndex);
    }
}
