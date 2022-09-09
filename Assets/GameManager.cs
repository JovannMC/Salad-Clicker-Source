using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float coins;
    private float coinsPerClick = 0.1f;
    private float coinsPerSecond = 0;

    private UpgradesManager upgradesManager;

    private void Start() 
    {
        upgradesManager = this.GetComponent<UpgradesManager>();

        checkSave();

        StartCoroutine(addCoinsPerSecond());
        StartCoroutine(autoSave());
    }

    private void Update() 
    {
        Application.quitting += Save;
    }

    public float getCoins() 
    {
        return coins;
    }

    public float getCoinsPerClick() 
    {
        return coinsPerClick;
    }

    public void setCoins(float amount) 
    {
        coins = amount;
    }

    public void setCoinsPerClick(float amount) 
    {
        coinsPerClick = amount;
    }

    public void setCoinsPerSecond(float amount) 
    {
        coinsPerSecond = amount;
    }

    public float getCoinsPerSecond() 
    {
        return coinsPerSecond;
    }

    private void Save() 
    {
        PlayerPrefs.SetFloat("coins", coins);
        PlayerPrefs.SetFloat("coinsPerClick", coinsPerClick);
        PlayerPrefs.SetFloat("coinsPerSecond", coinsPerSecond);
        PlayerPrefs.SetInt("coinsPerClickUpgradePrice", upgradesManager.getCoinsPerClickUpgradePrice());
        PlayerPrefs.SetInt("coinsPerSecondUpgradePrice", upgradesManager.getCoinsPerSecondUpgradePrice());
        
        print("saved");
    }

    public void checkSave() 
    {
        // Check if we have a saved game
        if (!PlayerPrefs.HasKey("coins")) 
        {
            PlayerPrefs.SetFloat("coins", 0);
            print("coins not found, creating coins playerpref with value of 0");
        }

        if (!PlayerPrefs.HasKey("coinsPerClick")) 
        {
            PlayerPrefs.SetFloat("coinsPerClick", 0.1f);
            print("coinsPerClick not found, creating coinsPerClick playerpref with value of 0.1");
        }

        if (!PlayerPrefs.HasKey("coinsPerSecond")) 
        {
            PlayerPrefs.SetFloat("coinsPerSecond", 0);
            print("coinsPerSecond not found, creating coinsPerSecond playerpref with value of 0");
        }

        if (!PlayerPrefs.HasKey("coinsPerClickUpgradePrice")) 
        {
            PlayerPrefs.SetFloat("coinsPerClickUpgradePrice", 5);
            print("coinsPerClickUpgradePrice not found, creating coinsPerClickUpgradePrice playerpref with value of 5");
        }

        if (!PlayerPrefs.HasKey("coinsPerSecondUpgradePrice")) 
        {
            PlayerPrefs.SetFloat("coinsPerSecondUpgradePrice", 10);
            print("coinsPerSecondUpgradePrice not found, creating coinsPerSecondUpgradePrice playerpref with value of 10");
        }

        coins = PlayerPrefs.GetFloat("coins");
        coinsPerClick = PlayerPrefs.GetFloat("coinsPerClick");
        coinsPerSecond = PlayerPrefs.GetFloat("coinsPerSecond");
        upgradesManager.setCoinsPerClickUpgradePrice(PlayerPrefs.GetInt("coinsPerClickUpgradePrice"));
        upgradesManager.setCoinsPerSecondUpgradePrice(PlayerPrefs.GetInt("coinsPerSecondUpgradePrice"));
    }

    IEnumerator autoSave() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(10);
            Save();
        }
    }

    IEnumerator addCoinsPerSecond() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            setCoins(coins + coinsPerSecond);
        }
    }
}
