using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Side { Player1 = 100, Player2 = 200, Player3 = 300, Player4 = 400}

public class Health : MonoBehaviour
{
    public float startHealth = 100f;
    public Side side;

    private float currentHealth;

    public Action OnDeath;

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0f)
        {
            Die();
        }
    }

    public void DoHeal(float heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Min( startHealth, currentHealth );
    }

    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
