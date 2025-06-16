using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RPSGesture { Rock, Paper, Scissor }

public class Enemy : MonoBehaviour
{
    public Image aiChoiceImage;
    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorSprite;

    private void Start()
    {
        StartCoroutine(ChoiceRoutine());
    }

    IEnumerator ChoiceRoutine()
    {
        while (true)
        { 
            
            yield return ChantCoroutine();// 가위바위보로그

            
            ChooseGesture();//3개중에 하나

           
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator ChantCoroutine()
    {
        Debug.Log("가위!");
        yield return new WaitForSeconds(1f);

        Debug.Log("바위!");
        yield return new WaitForSeconds(1f);

        Debug.Log("보!");
        yield return new WaitForSeconds(1f);
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
                break;
            case RPSGesture.Paper:
                aiChoiceImage.sprite = paperSprite;
                Debug.Log("AI : Paper");
                break;
            case RPSGesture.Scissor:
                aiChoiceImage.sprite = scissorSprite;
                Debug.Log("AI : Scissor");
                break;
        }
    }
}