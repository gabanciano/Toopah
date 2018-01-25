using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour {

    [Header("UI Objects")]
    public Text CoinText;
    public Text TopScoreText;
    public Button PlayButton;

    public Image SoundImage;

    public Image AboutScreen;
    [Space]

    [Header("Sound Toggle Sprites")]
    public Sprite SoundOnSprite;
    public Sprite SoundOffSprite;

    #region "Sound Toggle"
    void SoundToggleLoad()
    {
        if (PlayerPrefs.GetInt("soundenabled") == 1)
        {
            AudioListener.pause = true;
        }
        else if (PlayerPrefs.GetInt("soundenabled") == 0)
        {
            AudioListener.pause = false;
        }
        SoundToggleInit();
    }
    void SoundToggleInit()
    {
        if (!AudioListener.pause)
        {
            SoundImage.sprite = SoundOnSprite;
        }
        else if (AudioListener.pause)
        {
            SoundImage.sprite = SoundOffSprite;
        }
    }
    public void SoundToggle()
    {
        if (!AudioListener.pause)
        {
            AudioListener.pause = true;
            SoundImage.sprite = SoundOffSprite;
            PlayerPrefs.SetInt("soundenabled", 1);
        }
        else if (AudioListener.pause)
        {
            AudioListener.pause = false;
            SoundImage.sprite = SoundOnSprite;
            PlayerPrefs.SetInt("soundenabled", 0);
        }
    }
    #endregion

    void InitGameData()
    {
        GameData.playerCoins = PlayerPrefs.GetInt("PLAYER_COINS", 0);
        GameData.gameTopScore = PlayerPrefs.GetInt("PLAYER_TOP_SCORE", 0);
    }

    void Start()
    {
        SoundToggleInit();
        InitGameData();
    }

    void UpdateText()
    {
        CoinText.text = "" + GameData.playerCoins;
        TopScoreText.text = GameData.gameTopScore.ToString("000000");
    }

    void Update()
    {
        UpdateText();
        DetectKeyboard();
    }

    void DetectKeyboard()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            PlayGame();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level1-1");
    }

    #region "About Screen"#
    public void ShowAboutScreen()
    {
        AboutScreen.gameObject.SetActive(true);
    }
    public void HideAboutScreen()
    {
        AboutScreen.gameObject.SetActive(false);
    }
    #endregion

    public void GoToStore()
    {
        SceneManager.LoadScene("store");
    }
}
