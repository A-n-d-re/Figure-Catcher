using UnityEngine;

public class GameDifficultySetter : MonoBehaviour
{
    public void SetFigureFallingSpeed(int figureFallingSpeed)
    {
        if (figureFallingSpeed < 0)
        {
            Debug.LogError("Figure falling speed can't be below zero");

            figureFallingSpeed = 0;
        }

        PlayerPrefs.SetInt("FigureFallingSpeed", figureFallingSpeed);
    }
}
