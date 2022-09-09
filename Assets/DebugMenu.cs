using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugMenu : MonoBehaviour
{
    private TMP_Text coinsText;
    private TMP_Text coinsPerClickText;
    private TMP_Text coinsPerSecondText;

    private GameManager gameManager;

    [SerializeField] private GameObject debugMenu;

    private void Start()
    {
        gameManager = this.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (debugMenu.activeSelf) 
        {
            coinsText = GameObject.Find("CoinsText").GetComponent<TMP_Text>();
            coinsPerClickText = GameObject.Find("CoinsPerClickText").GetComponent<TMP_Text>();
            coinsPerSecondText = GameObject.Find("CoinsPerSecondText").GetComponent<TMP_Text>();

            coinsText.text = "coins: " + gameManager.getCoins();
            coinsPerClickText.text = "coinsPerClick: " + gameManager.getCoinsPerClick();
            coinsPerSecondText.text = "coinsPerSecond: " + gameManager.getCoinsPerSecond();

            if (Input.GetKeyDown(KeyCode.Equals))
            {
                debugMenu.SetActive(false);
            }
        } else {
            if (Input.GetKeyDown(KeyCode.Equals))
            {
                debugMenu.SetActive(true);
            }
        }
    }

    public void setCoins(string value) 
    {
        if (float.TryParse(value, out float result)) {
            gameManager.setCoins(result);
        }
    }

    public void setCoinsPerClick(string value)
    {
        if (float.TryParse(value, out float result)) {
            gameManager.setCoinsPerClick(result);
        }
    }

    public void setCoinsPerSecond(string value)
    {
        if (float.TryParse(value, out float result)) {
            gameManager.setCoinsPerSecond(result);
        }
    }

    public void resetButton() 
    {
        gameManager.setCoins(0);
        gameManager.setCoinsPerClick(1);
        gameManager.setCoinsPerSecond(0);

        PlayerPrefs.DeleteAll();

        print("save reset");

        gameManager.checkSave();
    }

}
