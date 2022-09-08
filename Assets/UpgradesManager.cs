using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesManager : MonoBehaviour
{
    private GameManager gameManager;

    void Start() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void upgradeCoinsPerClick()
    {
        gameManager.addCoinsPerClick(1);
        print("coins per click: " + gameManager.getCoinsPerClick());
    }

    public void upgradeCoinsPerSecond() 
    {
        gameManager.addCoinsPerSecond(1);
        print("coins per second: " + gameManager.getCoinsPerSecond());
    }
}
