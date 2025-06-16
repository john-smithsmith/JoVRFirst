using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreManager scoreManager;//�ν����Ϳ��� �ҷ�����

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
            Debug.Log($"[����] �÷��̾�: {playerGesture}, AI: {enemyGesture}");

            string result = GetResult(playerGesture.Value, enemyGesture.Value);
            Debug.Log($"���: {result}");

            switch (result)
            {
                case "�¸�!":
                    scoreManager.AddPlayerScore();
                    break;
                case "�й�!":
                    scoreManager.AddEnemyScore();
                    break;
            }

            if (scoreManager.HasPlayerWon())
            {
                Debug.Log("�÷��̾ �¸�!");
                scoreManager.ResetScores();
            }
            else if (scoreManager.HasEnemyWon())
            {
                Debug.Log("AI�� �¸�!");
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
                    case RPSGesture.Rock: return "���º�!";
                    case RPSGesture.Paper: return "�й�!";
                    case RPSGesture.Scissor: return "�¸�!";
                }
                break;

            case RPSGesture.Paper:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "�¸�!";
                    case RPSGesture.Paper: return "���º�!";
                    case RPSGesture.Scissor: return "�й�!";
                }
                break;

            case RPSGesture.Scissor:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "�й�!";
                    case RPSGesture.Paper: return "�¸�!";
                    case RPSGesture.Scissor: return "���º�!";
                }
                break;
        }

        return "���� ����";
    }

}