using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureDebugLogger : MonoBehaviour
{
    public enum GestureType { Rock, Paper, Scissors }

    public GestureType gesture;

    public void LogGesture()
    {
        Debug.Log($"player: {gesture}!");
        GameManager.Instance.SetPlayerGesture((RPSGesture)gesture);
    }
}