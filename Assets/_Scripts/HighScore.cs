using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text HighScoreTxt;

    private int highScore;
    private int score;

    private void Awake()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        HighScoreTxt.text = "HighScore : " + highScore;
        if (highScore < 0 || highScore == null)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
    }

    // Update is called once per frame
    void Update () {

        int score = PlayerPrefs.GetInt("Score");

        if (score >= highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            HighScoreTxt.text = "HighScore : " + highScore;
        }


    }
}
