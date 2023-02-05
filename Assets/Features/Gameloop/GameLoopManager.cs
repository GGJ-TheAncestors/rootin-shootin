using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLoopManager : MonoBehaviour
{
    // Starts a round by informing the timeloop controller, as well as the score manager & role manager.
    // 
    [SerializeField] private TimeLoopController TimeLoop;
    [SerializeField] private ScoreManager Scores;
    [SerializeField] private RoleManager Roles;
    [SerializeField] private CharacterManager Characters;
    [SerializeField] private ReferenceList Players;

    public TimeLoopController GetTimeLoopController() => TimeLoop;
    public ScoreManager GetScoreManager() => Scores;
    public RoleManager GetRoleManager() => Roles;
    public CharacterManager GetCharacters() => Characters;
    public ReferenceList GetPlayers() => Players;

    public Action OnGameComplete;

    // ScoreManager;
    // RoleManager;
    private int CurrentRound = 1;

    private int DeathCount;

    // Start is called before the first frame update
    void Start()
    {
        TimeLoop = GetComponentInChildren<TimeLoopController>();
        Scores = GetComponentInChildren<ScoreManager>();
        Roles = GetComponentInChildren<RoleManager>();
        Characters = GetComponentInChildren<CharacterManager>();
        TimeLoop.RoundEnd = RoundEnd;
        StartGame();
    }

    void RoundEnd()
    {
        Debug.Log("Player 1 role was: " + Roles.PlayerRoles[0].ToString());

        // TODO: Compare to the actual playercount.
        if (CurrentRound == Players.objects.Count)
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
        Roles.InitializeRoles();
        Characters.InstantiateCharacters();
        TimeLoop.StartTimers();
        ResetDeath();
    }

    public void NextRound()
    {
        // Add the remaining time as your score!
        // TODO: Discuss with team.
        Scores.AddScore(TimeLoop.RoundTimeUI, Roles.CurrentFarmerID);

        // Assign new roles to players, then clear existing player gameobjects and reinstantiate them.
        //
        Roles.RotateCharacters();
        Characters.ClearCharacters();
        Characters.InstantiateCharacters();
        
        // Start the next round!
        TimeLoop.ResetTimers();
        TimeLoop.StartTimers();
        ResetDeath();
        CurrentRound++;
    }

    public void GameComplete()
    {
        Debug.Log("Game Complete!");
        OnGameComplete?.Invoke();
        // TODO: Show scores, Give option to restart or go back to main menu?
    }

    public void RestartGame()
    {
        TimeLoop.ResetTimers();
        Scores.ResetScores();
        Roles.InitializeRoles();
    }

    public void ResetDeath()
    {
        DeathCount = 0;

        foreach( GameObject player in Players.objects )
        {
            if( player.TryGetComponent<Health>(out Health health ) )
                health.OnDeath += OnDeath;
        }
    }

    public void OnDeath()
    {
        ++DeathCount;

        if( DeathCount == Players.Count() - 1 )
        {
            TimeLoop.ResetTimers();
            RoundEnd();
        }
    }

}
