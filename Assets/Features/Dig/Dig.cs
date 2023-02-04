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

    void OnValidate()
    {
        health = GetComponent<Health>();
    }

    void Update()
    {
        CurrentCooldownTime -= Time.deltaTime;
        CurrentCooldownTime = Mathf.Max( 0, CurrentCooldownTime );
        
        if( isDigging )
            health.DoHeal( HealingAmount );
    }

    public void ActionResurface()
    {
        animator.SetBool( "Action_Dig", false );
        CurrentCooldownTime = CooldownTime;
    }

    public void ActionDig()
    {
        isDigging = true;
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