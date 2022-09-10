using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    private GameManager gameManager;

    private TMP_Text counter;

    void Start() 
    {
        counter = GameObject.Find("Counter").GetComponent<TMP_Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void updateCounter() 
    {
        gameManager.setCoins(gameManager.getCoins() + gameManager.getCoinsPerClick());
        print("added " + gameManager.getCoinsPerClick() + " coins, current coins: " + gameManager.getCoins());
        counter.text = gameManager.getCoins().ToString("0.0");
    }

    private void Update() 
    {
        counter.text = gameManager.getCoins().ToString("0.0");
    }
}
