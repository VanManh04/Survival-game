using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public float currentHealth, maxHealth;

    public Slider healthSlider;

    public GameObject deathEffect;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        maxHealth = PlayerStatController.instance.health[0].value;
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

            LevelManager.instance.EndLevel();

            Instantiate(deathEffect,transform.position,transform.rotation);

            LevelManager.instance.gameActive = false;

            SFXManager.instance.PlaySFX(3);
        }

        healthSlider.value = currentHealth;
    }
}
