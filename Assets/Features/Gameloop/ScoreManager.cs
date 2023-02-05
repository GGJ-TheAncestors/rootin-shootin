using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    // Manages scores for each player over all 4 rounds.
    // Supplies methods to add points to players.
    // TODO: Probably should add the player ReferenceList here.
    [SerializeField]
    private List<int> playerScores = new List<int> { 0, 0, 0, 0 };

    public Action<int, int> ScoreAction;

    public List<int> GetPlayerScores() => playerScores;

    public void AddScore(int score, int playerID)
    {
        playerScores[playerID] = score;
        ScoreAction?.Invoke(score, playerID);
    }

    public void ResetScores() 
    {
        for (int i = 0; i < playerScores.Count; i++)
        {
            playerScores[i] = 0;
        }
    }

    public int GetWinningPlayerID()
    {
        int playerID = playerScores.IndexOf(playerScores.Max());
        return (playerID);
    }
}
