using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        
    }

    public void TakeDamage(float DamageToTake)
    {
        currentHealth -= DamageToTake;

        if (currentHealth<=0)
        {
            gameObject.SetActive(false);
        }
    }
}
