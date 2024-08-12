using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(TimerUpdater))]
[RequireComponent(typeof(BasketColorChanger))]
public class FigureCatcher : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private AudioSource catchedFigureSound;

    private BasketColorChanger basketColorChanger;

    private TimerUpdater timerUpdater;

    private Animator animator;

    private int score;

    private void Start()
    {
        animator = GetComponent<Animator>();
        timerUpdater = GetComponent<TimerUpdater>();
        catchedFigureSound = GetComponent<AudioSource>();
        basketColorChanger = GetComponent<BasketColorChanger>();
    }

    private void Update()
    {
        if (timerUpdater.isGameOver)
        {
            int maxScore = PlayerPrefs.GetInt("MaxScore");

            if (score > maxScore)
            {
                PlayerPrefs.SetInt("MaxScore", score);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Figure"))
        {
            if (collision.GetComponent<SpriteRenderer>().color == basketColorChanger.CurrentColor)
            {
                score++;

                scoreText.text = $"Score: {score}";
            }
            else
            {
                if (score > 0)
                {
                    score--;

                    scoreText.text = $"Score: {score}";
                }
            }

            catchedFigureSound.Play();

            animator.SetTrigger("isCatchedFigure");
        }
    }
}
