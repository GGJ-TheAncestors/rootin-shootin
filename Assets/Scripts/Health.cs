using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float startHealth = 100f;

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

    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}
