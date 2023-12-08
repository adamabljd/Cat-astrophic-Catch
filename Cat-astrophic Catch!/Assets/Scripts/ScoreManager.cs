using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    private int score = 0;
    public static ScoreManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreDisplay();
    }


    // Method to increase the score
    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    // Method to decrease the score
    public void DecreaseScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;  // Prevents score from going negative
        UpdateScoreDisplay();
    }

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }

    // Update the UI display of the score (if you have a UI element for score)
    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
