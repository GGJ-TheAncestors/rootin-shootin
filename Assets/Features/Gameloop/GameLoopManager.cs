using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    // Starts a round by informing the timeloop controller, as well as the score manager & role manager.
    // 
    public TimeLoopController TimeLoop;
    public ScoreManager Score;

    // ScoreManager;
    // RoleManager;
    public int CurrentRound = 0;

    // Start is called before the first frame update
    void Start()
    {
        TimeLoop = GetComponentInChildren<TimeLoopController>();
        Score = GetComponentInChildren<ScoreManager>();
        TimeLoop.RoundEnd = delegate () { Debug.Log("The manager knows the round has ended!"); };
        // TODO: If any logic is needed before the round starts, insert here!!
        StartRound();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void StartRound()
    {
        Debug.Log("Round " + CurrentRound.ToString() + "!");
        TimeLoop.StartTimers();
    }

    public void EndGame()
    {
        // TODO: Go back to main menu?
    }

    public void RestartGame()
    {
        TimeLoop.RestartTimers();
        Score.ResetScores();
        
    }
}
