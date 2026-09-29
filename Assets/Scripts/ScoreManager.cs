using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int score = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;

        UpdateScoreText();

        //Debug.Log("Score : " + score);
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score : " + score;
    }
}