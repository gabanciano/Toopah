using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoreUIManager : MonoBehaviour {

    public Text CoinText;

    public Button BuyButton;
    public Text BuyButtonText;
    public Image PriceText;

    private void Start()
    {
        CoinText.text = "" + GameData.playerCoins;
    }

    private void Update()
    {
        BackPressed();
    }

    void BackPressed()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("menu");
    }
}
