using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour {

    [Header("Screen Effects")]
    public Image ScreenFadeOut;
    [Space]

    [Header("Game Over")]
    public Image GameOverPanel;
    [Space]

    [Header("Level Completed")]
    public Image LevelCompletedPanel;
    public Text TopScoreStatusText;
    public Text TotalLevelScore;
    [Space]

    public Text RevivePriceText;
    public Button ReviveButton;
    public Image GameControlsHolder;
    public Image TopBarHolder;

    [Header("Top Bar UI")]
    public Image CoinImage;
    [Space]

    [Header("Text UI")]
    public Text CoinText;
    public Text ScoreText;

    int reviveCost;

    void InitGameData()
    {
        GameData.playerScore = 0;
        GameData.playerCoins = PlayerPrefs.GetInt("PLAYER_COINS", 0);
        GameData.gameTopScore = PlayerPrefs.GetInt("PLAYER_TOP_SCORE", 0);
    }

     void Start()
    {
        InitGameData();
    }
    
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        CoinText.text = "" + GameData.playerCoins;
        ScoreText.text = "" + GameData.playerScore.ToString("000000");
    }
    
    public void ShowDiamondCounter()
    {
        CoinImage.gameObject.SetActive(false);
        CoinImage.gameObject.SetActive(true);
    }

    public IEnumerator FadeMenuGameOver()
    {
        GameOverPanel.gameObject.SetActive(true);
        GameControlsHolder.gameObject.SetActive(false);
        TopBarHolder.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        ScreenFadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("menu");
    }
    public IEnumerator FadeMenuCompleted()
    {
        LevelCompletedPanel.gameObject.SetActive(true);
        GameControlsHolder.gameObject.SetActive(false);
        TopBarHolder.gameObject.SetActive(false);
        TotalLevelScore.text = GameData.playerScore.ToString("000000");
        GameData.RecordTopScore();
        if (GameData.IsTopScoreNew())
        {
            TopScoreStatusText.text = "NEW TOP SCORE!";
        }
        else
        {
            TopScoreStatusText.text = "FINAL SCORE";
        }
        yield return new WaitForSeconds(3f);
        ScreenFadeOut.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("menu");
    }
    
    public void RevivePlayer()
    {
        GameData.totalDeathsThisSession++;
        reviveCost = 50 * GameData.totalDeathsThisSession;
        RevivePriceText.text = reviveCost.ToString();
        GameData.playerCoins -= reviveCost;
        PlayerPrefs.SetInt("PLAYER_COINS", GameData.playerCoins);
        GameData.playerAlive = true;
        FixNegativeCoins();
    }

    void FixNegativeCoins()
    {
        if(GameData.playerCoins <= 0)
        {
            GameData.playerCoins = 0;
            PlayerPrefs.SetInt("PLAYER_COINS", GameData.playerCoins);
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("menu");
    }

   
}
