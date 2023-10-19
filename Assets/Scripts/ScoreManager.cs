using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    public int currentScore;
    public int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        PlayerPrefs.GetInt("highscore", 0);
        currentScore = 0;
        scoreText.text = "Score: " + currentScore.ToString();
        highscoreText.text = "High score: " + highscore.ToString();

    }

    public void AddScore(int points)
    {
        currentScore += points;
        scoreText.text = "Score: " + currentScore.ToString();
        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
        }
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt("highscore", 0);
    }

}
