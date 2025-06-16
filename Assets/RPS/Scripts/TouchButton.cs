using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FingerTouchButton : MonoBehaviour
{
    public UnityEvent onTouch;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finger"))
        {
            onTouch.Invoke();
        }
    }
}