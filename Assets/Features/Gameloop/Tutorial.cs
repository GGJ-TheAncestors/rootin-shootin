using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private InputAction Next;

    [SerializeField]
    private UnityEvent OnPressed;

    // Start is called before the first frame update
    void Start()
    {
        Next.Enable();
        Next.performed += Pressed;
    }

    private void Pressed(InputAction.CallbackContext obj)
    {
        OnPressed.Invoke();

        Destroy( this.gameObject );
    }
}
