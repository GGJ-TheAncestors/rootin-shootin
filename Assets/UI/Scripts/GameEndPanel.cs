using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] RoleManager roleManager;
    [SerializeField] Transform scoreEntriesParent;
    [SerializeField] PlayerScoreEntry playerScoreEntryPrefab;
    private List<PlayerScoreEntry> playerScoreEntries = new List<PlayerScoreEntry>();

    [SerializeField]
    private InputAction ReturnToMenu;


    void OnEnable()
    {
        ReturnToMenu.Enable();
        ReturnToMenu.performed += OnReturnToMenu;
        SetScores();
    }

    void OnDisable()
    {
        ReturnToMenu.Disable();
        ReturnToMenu.performed -= OnReturnToMenu;
    }

    void SetScores()
    {
        //clear current entries
        foreach(var playerScoreEntry in playerScoreEntries)
        {
            Destroy(playerScoreEntry.gameObject);
        }
        playerScoreEntries.Clear();

        var playerCount = roleManager.PlayerRoles.Count;
        var playerScores = scoreManager.GetPlayerScores();
        for(int i = 0; i < playerCount; i++)
        {
            var newPlayerScoreEntry = Instantiate(playerScoreEntryPrefab, scoreEntriesParent);
            newPlayerScoreEntry.SetScore(playerScores[i], i);
            playerScoreEntries.Add(newPlayerScoreEntry);
        }
    }

    private void OnReturnToMenu(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }
}
