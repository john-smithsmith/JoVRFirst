using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Hands.Samples.GestureSample;

public class GestureLog : MonoBehaviour
{
    public StaticHandGesture RockGesture;
    public StaticHandGesture PaperGesture;
    public StaticHandGesture ScissorGesture;

    void Start()
    {
        RockGesture.gesturePerformed.AddListener(() => Debug.Log("Rock"));
        PaperGesture.gesturePerformed.AddListener(() => Debug.Log("Paper"));
        ScissorGesture.gesturePerformed.AddListener(() => Debug.Log("Scissor"));
    }
}
