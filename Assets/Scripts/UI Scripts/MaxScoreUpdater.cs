using UnityEngine;
using UnityEngine.UI;

public class MaxScoreUpdater : MonoBehaviour
{
    [SerializeField] private Text maxScoreCountText;

    private void Start()
    {
        int maxScore = PlayerPrefs.GetInt("MaxScore");

        maxScoreCountText.text = maxScore.ToString();
    }
}
