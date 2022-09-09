using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float coins;
    private float coinsPerClick = 0.1f;
    private float coinsPerSecond = 0;

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
        print("saved");
    }

    private void Start() 
    {
        checkSave();

        StartCoroutine(addCoinsPerSecond());
        StartCoroutine(autoSave());
    }

    private void Update() 
    {
        Application.quitting += Save;
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

        coins = PlayerPrefs.GetFloat("coins");
        coinsPerClick = PlayerPrefs.GetFloat("coinsPerClick");
        coinsPerSecond = PlayerPrefs.GetFloat("coinsPerSecond");
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
