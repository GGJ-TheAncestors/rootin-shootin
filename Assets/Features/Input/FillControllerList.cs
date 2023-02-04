using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FillControllerList : MonoBehaviour
{
    [SerializeField]
    private ReferenceList list;

    void Start()
    {
        list.Clear();
    }

    void OnDestroy()
    {
        Start();
    }


    void OnPlayerJoined( PlayerInput input )
    {
        list.Add( input.gameObject );
    }
}
