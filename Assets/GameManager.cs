using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int coins;
    private int coinsPerClick = 1;
    private int coinsPerSecond = 0;

    public int getCoins() 
    {
        return coins;
    }

    public int getCoinsPerClick() 
    {
        return coinsPerClick;
    }

    public void addCoins(int amount) 
    {
        coins += amount;
    }

    public void addCoinsPerClick(int amount) 
    {
        coinsPerClick += amount;
    }

    public void addCoinsPerSecond(int amount) 
    {
        coinsPerSecond += amount;
    }

    public int getCoinsPerSecond() 
    {
        return coinsPerSecond;
    }

    private void Start() 
    {
        StartCoroutine(addCoinsPerSecond());
    }

    IEnumerator addCoinsPerSecond() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(1);
            addCoins(coinsPerSecond);
        }
    }
}
