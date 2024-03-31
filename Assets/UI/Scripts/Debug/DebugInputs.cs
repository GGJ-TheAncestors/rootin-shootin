using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class DebugInputs : MonoBehaviour
{
    [SerializeField]
    private FillControllerList fillControllerList;

    [SerializeField]
    private PlayerInputManager manager;

    [SerializeField]
    private PlayerInput playerPrefab;

    [SerializeField]
    private ReferenceList controllerList;

    [SerializeField]
    private InputAction inputAction;

    // Start is called before the first frame update
    void Start()
    {
        if( !Debug.isDebugBuild )
            return;


        inputAction.performed += onInput;

        inputAction.Enable();
    }

    private void onInput(InputAction.CallbackContext context)
    {
        for( int i = controllerList.Count(); i < 4; ++i )
        {
            manager.JoinPlayerFromAction( context );
        }
    }

    void OnDestroy()
    {
        inputAction.Disable();
    }
}
