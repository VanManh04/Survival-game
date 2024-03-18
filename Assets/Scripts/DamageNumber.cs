using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI damageText;

    public float lifetime;
    private float lifeCounter;

    public float floatSpeed;

    void Update()
    {
        if(lifeCounter > 0)
        {
            lifeCounter -= Time.deltaTime;
            if (lifeCounter <= 0)
            {
                //Destroy(gameObject);
                DamageNumberController.instance.PlanceInPool(this);
            }
        }

        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }

    public void Setup(int damageDisplay)
    {
        lifeCounter = lifetime;
        damageText.text = damageDisplay.ToString();
    }
}
