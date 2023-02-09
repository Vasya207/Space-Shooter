using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        DisplayScore();
    }

    public void DisplayScore()
    {
        scoreText.text = "YOU SCORED \n" + scoreKeeper.GetScore();
    }
}
