using UnityEngine;

public class GameData : MonoBehaviour{

    //Game UI
    public static bool leftMovementPressed;
    public static bool rightMovementPressed;

    //Game 
    public static int totalDeathsThisSession; 

    public static bool playerAlive;
    public static bool playerGrounded;

    public static bool gameStarted;
    public static bool bossBattleStarted;

    public static int playerCurrentLife;
    public static int playerCoins;

    public static bool playerDirLeft;

    //Game Score
    public static int playerScore;
    public static int gameTopScore;

    public static void RecordTopScore()
    {
        if(GameData.playerScore > GameData.gameTopScore)
        {
            PlayerPrefs.SetInt("PLAYER_TOP_SCORE", GameData.playerScore);
        }
    }

    public static bool IsTopScoreNew()
    {
        if(GameData.playerScore > GameData.gameTopScore)
        {
            return true;
        } 
        else
        {
            return false;
        }
    }
    
}
