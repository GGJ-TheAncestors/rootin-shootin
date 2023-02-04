using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsPanel : MonoBehaviour
{
    [SerializeField] PlayerEntryPanel[] playerEntryPanels;
    [SerializeField] ReferenceList controllers;

    int playerCount;

    private void OnEnable()
    {
        controllers.OnAdded.AddListener(HandleControllerAdded);
    }

    private void OnDisable()
    {
        controllers.OnAdded.RemoveListener(HandleControllerAdded);
    }


    void HandleControllerAdded(GameObject newController)
    {
        var newInput = newController.GetComponent<PlayerInput>();
        var newPlayerIndex = newInput.playerIndex;
        playerEntryPanels[playerCount].SetPlayerInfo("Player" + newPlayerIndex);
        playerCount++;
    }
}
