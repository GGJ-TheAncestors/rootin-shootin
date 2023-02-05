using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dig : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float CooldownTime;
    [SerializeField]
    private float CurrentCooldownTime;
    private bool isDigging;
    
    [Header("Healing")]
    [SerializeField]
    private Health health;
    [SerializeField]
    private float HealingAmount;

    [Header("Audio")]
    [SerializeField]
    private AudioClip DigSound;
    [SerializeField]
    private AudioClip ResurfaceSound;
    [SerializeField]
    private AudioClip HealSound;

    private float audioTimer;
    [SerializeField]
    private float audioInterval;

    [SerializeField, HideInInspector]
    private AudioSource audioSource;

    void OnValidate()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        CurrentCooldownTime -= Time.deltaTime;
        CurrentCooldownTime = Mathf.Max( 0, CurrentCooldownTime );
        
        if( isDigging )
        {
            audioTimer -= Time.deltaTime;
            if( audioTimer < 0 )
            {
                audioSource.PlayOneShot( HealSound );
                audioTimer = audioInterval;
            }
            health.DoHeal( HealingAmount );
        }
    }

    public void ActionResurface()
    {
        isDigging = false;
        animator.SetBool( "Action_Dig", false );
        audioSource.PlayOneShot( ResurfaceSound );
        CurrentCooldownTime = CooldownTime;
    }

    public void ActionDig()
    {
        isDigging = true;
        audioTimer = 0.75f;
        audioSource.PlayOneShot( DigSound );
        animator.SetBool( "Action_Dig", true );
    }

    public bool PerformAction(float state)
    {
        if( CurrentCooldownTime > 0 )
            return false;

        if( state == 1 )
        {
            ActionDig();
            return true;
        }
        
        if( isDigging == false )
            return false;

        ActionResurface();
        return true;
    }
}