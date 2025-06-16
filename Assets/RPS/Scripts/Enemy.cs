using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum RPSGesture { Rock, Paper, Scissor }

public class Enemy : MonoBehaviour
{
    public Image aiChoiceImage;
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorSprite;
    public TMP_Text AICountText;

    private void Start()
    {
        StartCoroutine(ChoiceRoutine());
    }

    IEnumerator ChoiceRoutine()
    {
        while (true)
        { 
            
            yield return ChantCoroutine();// 가위바위보로그

            yield return new WaitForSeconds(1f);

            ChooseGesture();//3개중에 하나

            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator ChantCoroutine()
    {
        AICountText.text = "ROCK!";
        yield return new WaitForSeconds(1f);

        AICountText.text = "PAPER";
        yield return new WaitForSeconds(1f);

        AICountText.text = "SICCOR!";
        yield return new WaitForSeconds(1f);
        AICountText.text = ""; 
    }

    void ChooseGesture()
    {
        int choice = Random.Range(0, 3);
        RPSGesture gesture = (RPSGesture)choice;

        switch (gesture)
        {
            case RPSGesture.Rock:
                aiChoiceImage.sprite = rockSprite;
                Debug.Log("AI : Rock");
                GameManager.Instance.SetEnemyGesture(RPSGesture.Rock);
                break;

            case RPSGesture.Paper:
                aiChoiceImage.sprite = paperSprite;
                Debug.Log("AI : Paper");
                GameManager.Instance.SetEnemyGesture(RPSGesture.Paper);
                break;

            case RPSGesture.Scissor:
                aiChoiceImage.sprite = scissorSprite;
                Debug.Log("AI : Scissor");
                GameManager.Instance.SetEnemyGesture(RPSGesture.Scissor);
                break;
        }
       
    }
}