using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public int currentScore = 0;
    public int highscore;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = "Score: " + currentScore.ToString();
        highscoreText.text = "High score: " + PlayerPrefs.GetInt("highscore");

    }

    public void AddScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
        if (currentScore > highscore)
        {
            highscore = currentScore;
            PlayerPrefs.SetInt("highscore", currentScore);
        }
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }

}
