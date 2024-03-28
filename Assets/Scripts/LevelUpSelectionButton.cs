using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpSelectionButton : MonoBehaviour
{
    public TMP_Text upgradeDescText, nameLevelText;
    public Image weaponIcon;

    private Weapon assignedWeapon;
    public void UpdateButtonDisplay(Weapon TheWeapon)
    {
        if (TheWeapon.gameObject.activeSelf == true)
        {
            upgradeDescText.text = TheWeapon.stats[TheWeapon.weaponLevel].upgradeText;
            weaponIcon.sprite = TheWeapon.icon;

            nameLevelText.text = TheWeapon.name + " - Lvl " + TheWeapon.weaponLevel;
        }else
        {
            upgradeDescText.text = "Unlock " + TheWeapon.name;
            weaponIcon.sprite = TheWeapon.icon;

            nameLevelText.text = TheWeapon.name;
        }

        assignedWeapon = TheWeapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            if(assignedWeapon.gameObject.activeSelf == true)
            {
                assignedWeapon.LevelUp();
            }else
            {
                PlayerController.instance.AddWeapon(assignedWeapon);
            }

            UIController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
