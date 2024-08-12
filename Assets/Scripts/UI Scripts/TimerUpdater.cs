using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerUpdater : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private Text timerCountText;

    [SerializeField] private int timer;

    public bool isGameOver {  get; private set; }

    private void Start()
    {
        timerCountText.text = timer.ToString();

        StartCoroutine(WaitToDecreaseTimer());
    }

    private IEnumerator WaitToDecreaseTimer()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);

            timer--;

            timerCountText.text = timer.ToString();

            if (timer == 0)
            {
                gameOverPanel.SetActive(true);

                Time.timeScale = 0f;

                isGameOver = true;
            }
        }
    }
}
