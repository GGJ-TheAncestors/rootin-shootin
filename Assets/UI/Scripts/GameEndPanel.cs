using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField]
    private InputAction ReturnToMenu;

    void OnEnable()
    {
        ReturnToMenu.Enable();
        ReturnToMenu.performed += OnReturnToMenu;
    }

    void OnDisable()
    {
        ReturnToMenu.Disable();
        ReturnToMenu.performed -= OnReturnToMenu;
    }

    private void OnReturnToMenu(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }
}
