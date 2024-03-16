using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    public Slider healthSlider;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
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

        healthSlider.value = currentHealth;
    }
}
