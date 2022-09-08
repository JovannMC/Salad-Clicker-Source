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

    public void addCoins(float amount) 
    {
        coins += amount;
    }

    public void addCoinsPerClick(float amount) 
    {
        coinsPerClick += amount;
    }

    public void addCoinsPerSecond(float amount) 
    {
        coinsPerSecond += amount;
    }

    public float getCoinsPerSecond() 
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
