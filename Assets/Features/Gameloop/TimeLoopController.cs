using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeLoopController : MonoBehaviour
{
    // Main timeloop controller.
    // Manages the round time, and the countdown time.
    //
    public bool RoundActive { get; private set; } = false;

    public int Players = 2; // TODO: Get an actual list of players

    // Keep track of the current round.
    [SerializeField]
    private int RoundDuration = 60;
    private float RoundTime = 60;
    public int RoundTimeUI { get; private set; } = 60;

    // Countdown vars.
    private bool CountDownActive = false;
    private int CountDownDuration = 3;
    private float CountDownTime = 3; // Time to count down from
    public int CountDownTimeUI { get; private set; } = 3;

    public Action RoundEnd;

    // Update is called once per frame
    void Update()
    {
        // Main time loop.
        if (RoundActive)
        {
            RoundTime -= Time.deltaTime;
            RoundTimeUI = Mathf.CeilToInt(RoundTime);

            if (RoundTime <= 0)
            {
                RoundActive = false;
                Debug.Log("Round ended!");
                RoundEnd?.Invoke();
            }
        }

        // A countdown and then we start.
        //
        if (CountDownActive)
        {
            CountDownTime -= Time.deltaTime;
            int prevCountDownTimeUI = CountDownTimeUI;
            CountDownTimeUI = Mathf.CeilToInt(CountDownTime);

            if (prevCountDownTimeUI != CountDownTimeUI)
            {
                Debug.Log(CountDownTimeUI == 0 ? "GO" : CountDownTimeUI.ToString() + "...");
            }

            if (CountDownTime <= 0)
            {
                RoundActive = true;

                // Immediately start keeping track of the time.
                //
                RoundTime += CountDownTime * -1;

                // Reset the countdown
                CountDownTime = CountDownDuration;
                CountDownActive = false;
            }
        }
    }

    /// <summary>
    /// Stops and restarts the timers.
    /// </summary>
    public void RestartTimers()
    {
        // Start the countdown to the first round.
        CountDownTime = CountDownDuration;
        CountDownTimeUI = CountDownDuration;
        CountDownActive = false;

        RoundTime = RoundDuration;
        RoundTimeUI = RoundDuration;
        RoundActive = false;

        Debug.Log("Start countdown!");
        Debug.Log("3...");
    }

    /// <summary>
    /// Restarts the timers and activates a countdown.
    /// </summary>
    public void StartTimers()
    {
        RestartTimers();
        CountDownActive = true;
    }
}
