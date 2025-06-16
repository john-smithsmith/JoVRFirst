using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreManager scoreManager;//�ν����Ϳ��� �ҷ�����
    public GameObject restartButton;
    public TMP_Text resultText;
    public TMP_Text AICountText;

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
    public void RestartGame()
    {
        scoreManager.ResetScores();
        //restartButton.SetActive(false);
    }

    public void ShowResultUI(string message)
    {
        if (resultText != null)
        {
            resultText.text = message;

            
            CancelInvoke(nameof(ClearResultUI));
            Invoke(nameof(ClearResultUI), 2f);
        }
    }

    public void ClearResultUI()
    {
        resultText.text = "";
    }

    public void TryJudge()
    {
        if (playerGesture.HasValue && enemyGesture.HasValue)
        {
            Debug.Log($"[����] �÷��̾�: {playerGesture}, AI: {enemyGesture}");

            string result = GetResult(playerGesture.Value, enemyGesture.Value);
            Debug.Log($"���: {result}");

            ShowResultUI(result);

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
                Debug.Log("�÷��̾� �¸�!");
                scoreManager.ResetScores();
            }
            else if (scoreManager.HasEnemyWon())
            {
                Debug.Log("AI �¸�!");
                scoreManager.ResetScores();
            }

            playerGesture = null;
            enemyGesture = null;
        }

        if (scoreManager.HasPlayerWon() || scoreManager.HasEnemyWon())
        {
            Debug.Log("���� ����");
            restartButton.SetActive(true);  // Restart ��ư
        }
    }

    public string GetResult(RPSGesture player, RPSGesture enemy)
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

    public void Restart()
    {
        CancelInvoke();

        scoreManager.ResetScores();

        if (resultText != null)
            resultText.text = "";

        if (AICountText != null)
            AICountText.text = "";

        

        playerGesture = null;

        enemyGesture = null;

        Debug.Log("�ʱ�ȭ");

    }

}