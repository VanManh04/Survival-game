using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider explvlSlider;
    public TMP_Text expLvlText;

    public LevelUpSelectionButton[] levelUpButtons;

    public GameObject levelUpPanel;

    public TMP_Text coinText;

    public PlayerStatUpgradeDisplay moveSpeedUpgradeDisplay, healthUpgradeDisplay, pickupRangeUpgradeDisplay, maxWeaponsUpgradeDisplay;
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void UpdateExperience(int currentExp, int levelExp, int currentLvl)
    {
        explvlSlider.maxValue = levelExp;
        explvlSlider.value = currentExp;

        expLvlText.text = "Level: " + currentLvl;
    }

    public void SkipLevelUp()
    {
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void UpdateCoins()
    {
        coinText.text = "Coin: " + CoinController.instance.currentCoins;
    }

    public void PurchaseMoveSpeed()
    {
        PlayerStatController.instance.PurchaseMoveSpeed();
        SkipLevelUp();
    }

    public void PurchaseHealth()
    {
        PlayerStatController.instance.PurchaseHealth();
        SkipLevelUp();
    }

    public void PurchasePickupRange()
    {
        PlayerStatController.instance.PurchasePickupRange();
        SkipLevelUp();
    }

    public void PurchaseMaxWeapons()
    {
        PlayerStatController.instance.PurchaseMaxWeapons();
        SkipLevelUp();
    }
}
