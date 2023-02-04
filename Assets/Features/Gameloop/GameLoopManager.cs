using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    // Starts a round by informing the timeloop controller, as well as the score manager & role manager.
    // 
    public TimeLoopController TimeLoop;
    public ScoreManager Scores;
    public RoleManager Roles;
    public int PlayerCount = 4; // TODO: temp var
    // ScoreManager;
    // RoleManager;
    private int CurrentRound = 1;

    // Start is called before the first frame update
    void Start()
    {
        TimeLoop = GetComponentInChildren<TimeLoopController>();
        Scores = GetComponentInChildren<ScoreManager>();
        Roles = GetComponentInChildren<RoleManager>();

        TimeLoop.RoundEnd = RoundEnd;
        StartGame();
    }

    void RoundEnd()
    {
        // TODO: Compare to the actual playercount.
        if (CurrentRound == PlayerCount)
        {
            GameComplete();
        }
        else
        {
            NextRound();
        }
    }
    void StartGame()
    {
        // TODO: If any logic is needed before the first round starts, insert here!!
        Debug.Log("Round " + CurrentRound.ToString() + "!");
        TimeLoop.StartTimers();
    }

    public void NextRound()
    {
        // Add the remaining time as your score!
        // TODO: Discuss with team.
        Scores.AddScore(TimeLoop.RoundTimeUI, Roles.CurrentFarmerID);
        TimeLoop.ResetTimers();
        TimeLoop.StartTimers();
        Roles.NextFarmer();
        CurrentRound++;
    }

    public void GameComplete()
    {
        Debug.Log("Game Complete!");
        // TODO: Show scores, Give option to restart or go back to main menu?
    }

    public void RestartGame()
    {
        TimeLoop.ResetTimers();
        Scores.ResetScores();
        Roles.Reset();
    }
}
