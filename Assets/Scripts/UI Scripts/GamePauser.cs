using UnityEngine;

public class GamePauser : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void UnPauseTheGame()
    {
        Time.timeScale = 1f;
    }
}
