using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public TMP_Text scoreText;
    public TMP_Text defeatScoreText;

    public int savedBestScore;
    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        scoreText = GameObject.Find("CurrentScore").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        Debug.Log(savedBestScore);
    }

    public void SetBestScore()
    {
        defeatScoreText.text = score.ToString();
        savedBestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > savedBestScore)
        {
            // Update PlayerPrefs
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }
}
