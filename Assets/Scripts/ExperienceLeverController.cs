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

    public List<Weapon> weaponsToUpgrade;

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
        //Debug.Log(weaponsToUpgrade.Count);
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
        //PlayerController.instance.activeWeapon.LevelUp();
        UIController.instance.levelUpPanel.SetActive(true);
        Time.timeScale = 0f;

        //UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.activeWeapon);
        //UIController.instance.levelUpButtons[0].UpdateButtonDisplay(PlayerController.instance.assignedWeapons[0]);

        //UIController.instance.levelUpButtons[1].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[0]);
        //UIController.instance.levelUpButtons[2].UpdateButtonDisplay(PlayerController.instance.unassignedWeapons[1]);

        weaponsToUpgrade.Clear();

        List<Weapon> availableWeapons = new List<Weapon>();
        availableWeapons.AddRange(PlayerController.instance.assignedWeapons);

        if(availableWeapons.Count > 0)
        {
            int selected = Random.Range(0,availableWeapons.Count);
            weaponsToUpgrade.Add(availableWeapons[selected]);
            availableWeapons.RemoveAt(selected);
        }

        //unlock weapon
        if (PlayerController.instance.assignedWeapons.Count+PlayerController.instance.fullyLevelledWeapons.Count < PlayerController.instance.maxWeapons)
        {
            availableWeapons.AddRange(PlayerController.instance.unassignedWeapons);
        }

        for (int i = weaponsToUpgrade.Count; i < 3; i++)
        {
            if (availableWeapons.Count > 0)
            {
                int selected = Random.Range(0, availableWeapons.Count);
                weaponsToUpgrade.Add(availableWeapons[selected]);
                availableWeapons.RemoveAt(selected);
            }
        }

        for (int i = 0; i < weaponsToUpgrade.Count; i++)
        {
            UIController.instance.levelUpButtons[i].UpdateButtonDisplay(weaponsToUpgrade[i]);
        }

        for (int i = 0; i < UIController.instance.levelUpButtons.Length; i++)
        {
            if (i < weaponsToUpgrade.Count)
            {
                UIController.instance.levelUpButtons[i].gameObject.SetActive(true);
            }else
            {
                UIController.instance.levelUpButtons[i].gameObject.SetActive(false);
            }
        }

        PlayerStatController.instance.UpdateDisplay();
    }

    public void SpawnExp(Vector3 position,int expValues)
    {
        Instantiate(pickup, position, Quaternion.identity).expValue = expValues;
    }
}
