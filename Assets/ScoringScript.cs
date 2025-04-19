using UnityEngine;
using UnityEngine.UI;

public class ScoringScript : MonoBehaviour
{

    public Text ScoreText;
    public GameObject WinScreen;
    public GameObject ScoringScreen;
    public GameObject LoseScreen;
    public int score = 0;
    public int threshold = 10;
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        UpdateScore();
        if (score == threshold)
        {

            ScoringScreen.SetActive(false);
            WinScreen.SetActive(true);
        }
    }

    public void AddScore()
    {
        score++;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Shoe: " + score.ToString();
    }
}
