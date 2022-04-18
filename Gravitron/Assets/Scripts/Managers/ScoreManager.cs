using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager ScoreManagerInstance { get; set; }
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public int score;

    private void Awake()
    {
        if (ScoreManagerInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            ScoreManagerInstance = this;
        }

        DontDestroyOnLoad(ScoreManagerInstance);
    }

    void Start()
    {
        scoreText = this.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
        //Debug.Log(PlayerPrefs.GetInt("highScore", 0).ToString());
        highScoreText = this.transform.GetChild(0).GetChild(5).GetComponent<TextMeshProUGUI>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore", 0).ToString();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
