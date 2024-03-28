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
        upgradeDescText.text = TheWeapon.stats[TheWeapon.weaponLevel].upgradeText;
        weaponIcon.sprite = TheWeapon.icon;

        nameLevelText.text = TheWeapon.name + " - Lvl " + TheWeapon.weaponLevel;

        assignedWeapon = TheWeapon;
    }

    public void SelectUpgrade()
    {
        if(assignedWeapon != null)
        {
            assignedWeapon.LevelUp();

            UIController.instance.levelUpPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
