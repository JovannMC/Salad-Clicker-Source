using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugStats : MonoBehaviour
{
    private TMP_Text coinsText;
    private TMP_Text coinsPerClickText;
    private TMP_Text coinsPerSecondText;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = this.GetComponent<GameManager>();
        coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
        coinsPerClickText = GameObject.Find("CoinsPerClickText").GetComponent<TMP_Text>();
        coinsPerSecondText = GameObject.Find("CoinsPerSecondText").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        coinsText.text = "coins: " + gameManager.getCoins();
        coinsPerClickText.text = "coinsPerClick: " + gameManager.getCoinsPerClick();
        coinsPerSecondText.text = "coinsPerSecond: " + gameManager.getCoinsPerSecond();
    }
}
