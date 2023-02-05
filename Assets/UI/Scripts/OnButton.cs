using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnButton : MonoBehaviour
{
    public UnityEvent pressed;

    public void OnButtonEvent()
    {
        pressed.Invoke();
    }
}
