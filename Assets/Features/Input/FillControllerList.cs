using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System;

public class FillControllerList : MonoBehaviour
{
    [SerializeField]
    private ReferenceList list;

    private bool destroy;

    void Start()
    {
        DontDestroyOnLoad( this.gameObject );
        SceneManager.sceneLoaded += OnSceneLoaded;
        
        list.Clear();
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if( arg0.buildIndex == 0 && destroy == true )
            Destroy( this.gameObject );

        if( arg0.buildIndex != 0 )
        {
            destroy = true;
            GetComponent<PlayerInputManager>().DisableJoining();
        }
    }

    void OnDestroy()
    {
        list.Clear();
        list.ClearEvent();
    }


    void OnPlayerJoined( PlayerInput input )
    {
        list.Add( input.gameObject );
    }
}
