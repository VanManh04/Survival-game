using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceLeverController : MonoBehaviour
{
    public static ExperienceLeverController instance;
    private void Awake()
    {
        instance = this;
    }

    public int currentExperience;

    public ExpPickup pickup;

    public List<int> expLevers;
    public int currentLever = 1, levelCount = 100;
    void Start()
    {
        while (expLevers.Count<levelCount)
        {
            //expLevers.Add(Mathf.RoundToInt(expLevers[expLevers.Count-1]*1.1f));
            expLevers.Add(Mathf.CeilToInt(expLevers[expLevers.Count-1]*1.1f));//co ,
        }
    }
    void Update()
    {
        
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;

        if (currentExperience >= expLevers[currentLever])
        {
            LevelUp();
        }

        UIController.instance.UpdateExperience(currentExperience, expLevers[currentLever],currentLever);
    }

    private void LevelUp()
    {
        currentExperience -= expLevers[currentLever];
        currentLever++;

        if (currentLever >= expLevers.Count)
        {
            currentLever =expLevers.Count-1;
        }
    }

    public void SpawnExp(Vector3 position,int expValues)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValues; ;
    }
}
