using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text currentScoreText;

    int score;
    int highScore;

    void Start() {
        LoadHighScore();
    }

    void OnEnable() {
        EventManager.OnStartGame += ResetScore;
        EventManager.OnPlayerDeath += CheckHighScore;
        EventManager.OnScorePoints += AddScore;
    }

    void OnDisable() {
        EventManager.OnStartGame -= ResetScore;
        EventManager.OnPlayerDeath -= CheckHighScore;
        EventManager.OnScorePoints -= AddScore;
    }

    void ResetScore() {
        score = 0;
    }

    void AddScore(int amount) {
        score += amount;
    }

    void LoadHighScore() {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        DisplayHighScore();
    }

    void CheckHighScore() {
        if (score > highScore) {
            PlayerPrefs.SetInt("HighScore", score);
            DisplayHighScore();
        }
    }

    void DisplayCurrentScore() {
        currentScoreText.text = score.ToString();
    }

    void DisplayHighScore() {
        highScoreText.text = highScore.ToString();
    }
}
