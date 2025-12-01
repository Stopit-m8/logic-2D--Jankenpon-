using TMPro;
using UnityEngine;

public class BestScoreMenu : MonoBehaviour
{
    public TMP_Text bestScoreText;

    private void OnEnable()
    {
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestScoreText.text = bestScore.ToString();
    }
}
