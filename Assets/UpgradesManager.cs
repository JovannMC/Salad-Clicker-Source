using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    private GameManager gameManager;

    private int coinsPerClickUpgradePrice = 5;
    private int coinsPerSecondUpgradePrice = 10;

    [SerializeField] private TMP_Text coinsPerClickPriceText;
    [SerializeField] private TMP_Text coinsPerSecondPriceText;

    void Start() 
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void upgradeCoinsPerClick()
    {
        if (gameManager.getCoins() >= coinsPerClickUpgradePrice) 
        {
            gameManager.addCoins(-coinsPerClickUpgradePrice);
            gameManager.addCoinsPerClick(0.1f);

            coinsPerClickUpgradePrice += 10;
            coinsPerClickPriceText.text = "Price: " + coinsPerClickUpgradePrice;

            print("coins per click: " + gameManager.getCoinsPerClick());
            print("coins per click upgrade price: " + coinsPerClickUpgradePrice);
        }
        
    }

    public void upgradeCoinsPerSecond() 
    {
        if (gameManager.getCoins() >= coinsPerSecondUpgradePrice) 
        {
            gameManager.addCoins(-coinsPerSecondUpgradePrice);
            gameManager.addCoinsPerSecond(1);

            coinsPerSecondUpgradePrice += 20;
            coinsPerSecondPriceText.text = "Price: " + coinsPerSecondUpgradePrice;

            print("coins per second: " + gameManager.getCoinsPerSecond());
            print("coins per second upgrade price: " + coinsPerSecondUpgradePrice);
        }
    }
}
