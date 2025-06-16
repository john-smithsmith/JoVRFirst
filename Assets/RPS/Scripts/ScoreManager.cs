using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore { get; private set; } = 0;
    public int enemyScore { get; private set; } = 0;
    public int winningScore = 3;

    [Header("UI")]
    public TMP_Text playerScoreText;
    public TMP_Text enemyScoreText;

    public void AddPlayerScore()
    {
        playerScore++;
        UpdateScoreUI();
    }

    public void AddEnemyScore()
    {
        enemyScore++;
        UpdateScoreUI();
    }

    public bool HasPlayerWon() => playerScore >= winningScore;
    public bool HasEnemyWon() => enemyScore >= winningScore;

    public void ResetScores()
    {
        playerScore = 0;
        enemyScore = 0;
        UpdateScoreUI();
        Debug.Log("점수가 초기화");
    }

    void UpdateScoreUI()
    {
        if (playerScoreText != null)
            playerScoreText.text = $"Player: {playerScore}";

        if (enemyScoreText != null)
            enemyScoreText.text = $"AI: {enemyScore}";
    }
}
