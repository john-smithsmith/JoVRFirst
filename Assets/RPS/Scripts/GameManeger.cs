using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ScoreManager scoreManager;//인스펙터에서 불러오기
    //public GameObject restartButton;
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
        //TryJudge();
    }
    //public void RestartGame()
    //{
    //    scoreManager.ResetScores();
    //    restartButton.SetActive(false);
    //}

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
            Debug.Log($"[who] Player: {playerGesture}, AI: {enemyGesture}");

            string result = GetResult(playerGesture.Value, enemyGesture.Value);
            Debug.Log($"result: {result}");

            ShowResultUI(result);

            switch (result)
            {
                case "Win!":
                    scoreManager.AddPlayerScore();
                    break;
                case "Lose!":
                    scoreManager.AddEnemyScore();
                    break;
            }

            playerGesture = null;
            enemyGesture = null;

            if (scoreManager.HasPlayerWon())
            {
                Debug.Log("player win!");
                ShowResultUI("Player Win!");
                scoreManager.ResetScores();
            }
            else if (scoreManager.HasEnemyWon())
            {
                Debug.Log("AI win!");
                ShowResultUI("AI Win!");
                scoreManager.ResetScores();
            }

           
        }

        if (scoreManager.HasPlayerWon() || scoreManager.HasEnemyWon())
        {
            Debug.Log("end");
            //restartButton.SetActive(true);  // Restart 버튼
        }
    }

    public string GetResult(RPSGesture player, RPSGesture enemy)
    {
        switch (player)
        {
            case RPSGesture.Rock:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "draw!";
                    case RPSGesture.Paper: return "lose!";
                    case RPSGesture.Scissor: return "win!";
                }
                break;

            case RPSGesture.Paper:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "win!";
                    case RPSGesture.Paper: return "draw!";
                    case RPSGesture.Scissor: return "lose!";
                }
                break;

            case RPSGesture.Scissor:
                switch (enemy)
                {
                    case RPSGesture.Rock: return "lose!";
                    case RPSGesture.Paper: return "win!";
                    case RPSGesture.Scissor: return "draw!";
                }
                break;
        }

        return "error";
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

        Debug.Log("restart");

    }
    public void QuitGame()
    {
        Application.Quit();

        
    }


}