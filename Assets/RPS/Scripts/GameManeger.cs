using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreManager scoreManager;//인스펙터에서 불러오기

    private RPSGesture? playerGesture = null;
    private RPSGesture? enemyGesture = null;

    void Awake()
    {
        Instance = this;
    }

    public void SetPlayerGesture(RPSGesture gesture)
    {
        playerGesture = gesture;
        TryJudge();
    }

    public void SetEnemyGesture(RPSGesture gesture)
    {
        enemyGesture = gesture;
        TryJudge();
    }

    void TryJudge()
    {
        if (playerGesture.HasValue && enemyGesture.HasValue)
        {
            Debug.Log($"[판정] 플레이어: {playerGesture}, AI: {enemyGesture}");

            string result = GetResult(playerGesture.Value, enemyGesture.Value);
            Debug.Log($"결과: {result}");

            switch (result)
            {
                case "승리!":
                    scoreManager.AddPlayerScore();
                    break;
                case "패배!":
                    scoreManager.AddEnemyScore();
                    break;
            }

            if (scoreManager.HasPlayerWon())
            {
                Debug.Log("플레이어가 승리!");
                scoreManager.ResetScores();
            }
            else if (scoreManager.HasEnemyWon())
            {
                Debug.Log("AI가 승리!");
                scoreManager.ResetScores();
            }

            playerGesture = null;
            enemyGesture = null;
        }
    }

    string GetResult(RPSGesture player, RPSGesture enemy)
    {
        switch (player)
        {
            case RPSGesture.Rock:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "무승부!";
                    case RPSGesture.Paper: return "패배!";
                    case RPSGesture.Scissor: return "승리!";
                }
                break;

            case RPSGesture.Paper:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "승리!";
                    case RPSGesture.Paper: return "무승부!";
                    case RPSGesture.Scissor: return "패배!";
                }
                break;

            case RPSGesture.Scissor:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "패배!";
                    case RPSGesture.Paper: return "승리!";
                    case RPSGesture.Scissor: return "무승부!";
                }
                break;
        }

        return "판정 오류";
    }

}