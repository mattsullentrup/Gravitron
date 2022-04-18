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

        LoadHighscores();
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        //if (score > PlayerPrefs.GetInt("highScore", 0))
        //{
        //    PlayerPrefs.SetInt("highScore", score);
        //}
    }

    List<HighscoreElement> highscoreList = new List<HighscoreElement>();
    [SerializeField] int maxCount = 7;
    [SerializeField] string filename;

    public delegate void OnHighscoreListChanged(List<HighscoreElement> list);
    public static event OnHighscoreListChanged onHighscoreListChanged;

    //private void Start()
    //{
    //    LoadHighscores();
    //}

    private void LoadHighscores()
    {
        highscoreList = FileHandler.ReadListFromJSON<HighscoreElement>(filename);

        while (highscoreList.Count > maxCount)
        {
            highscoreList.RemoveAt(maxCount);
        }

        if (onHighscoreListChanged != null)
        {
            onHighscoreListChanged.Invoke(highscoreList);
        }
    }

    private void SaveHighscore()
    {
        FileHandler.SaveToJSON<HighscoreElement>(highscoreList, filename);
    }

    public void AddHighscoreIfPossible(HighscoreElement element)
    {
        for (int i = 0; i < maxCount; i++)
        {
            if (i >= highscoreList.Count || element.points > highscoreList[i].points)
            {
                // add new high score
                highscoreList.Insert(i, element);

                while (highscoreList.Count > maxCount)
                {
                    highscoreList.RemoveAt(maxCount);
                }

                SaveHighscore();

                if (onHighscoreListChanged != null)
                {
                    onHighscoreListChanged.Invoke(highscoreList);
                }

                break;
            }
        }
    }
}
