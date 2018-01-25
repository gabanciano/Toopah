using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public GameUIManager GameUI;
    public SFXManager sfx;

    [Header("Game Elements")]
    public GameObject Bullet;
    [Space]

    [Header("Player Settings")]
    public float movementSpeed;
    public float jumpForce;

    bool onMovingPlatform;

    Rigidbody2D PlayerRigid;
    SpriteRenderer PlayerSprite;
    Animator PlayerAnimator;

    public Animator RainbowWearAnims;

    void InitPlayerData()
    {
        GameData.leftMovementPressed = false;
        GameData.rightMovementPressed = false;
        GameData.bossBattleStarted = false;
        GameData.playerAlive = true;
        
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerSprite = GetComponent<SpriteRenderer>();
        PlayerAnimator = GetComponent<Animator>();
    }

    void Start()
    {
        InitPlayerData();
    }

    void Update()
    {
        CheckMovements();
        DetectKeyboard();
    }

    void DetectKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayerLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopMovement();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayerRight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopMovement();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerJump();
        }
    }

    void CheckMovements()
    {
        if (GameData.leftMovementPressed)
        {
            MovePlayerLeft();
        }

        if (GameData.rightMovementPressed)
        {
            MovePlayerRight();
        }
    }

    #region "Movement"
    public void PlayerJump()
    {
        if (GameData.playerGrounded)
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, jumpForce);
            PlayerAnimator.SetInteger("sheep_state", 2);
            sfx.player_jump.Play();
        }
    }

    void MovePlayerLeft()
    {
        PlayerRigid.velocity = new Vector2(-movementSpeed, PlayerRigid.velocity.y);
    }

    void MovePlayerRight()
    {
        PlayerRigid.velocity = new Vector2(movementSpeed, PlayerRigid.velocity.y);
    }
    public void LeftMovementPressed()
    {
        GameData.leftMovementPressed = true;
        PlayerAnimator.SetInteger("sheep_state", 1);
        GameData.playerDirLeft = true;
        PlayerSprite.flipX = true;
    }
    public void RightMovementPressed()
    {
        GameData.rightMovementPressed = true;
        PlayerAnimator.SetInteger("sheep_state", 1);
        GameData.playerDirLeft = false;
        PlayerSprite.flipX = false;
    }
    public void StopMovement()
    {
        GameData.rightMovementPressed = false;
        GameData.leftMovementPressed = false;
        PlayerAnimator.SetInteger("sheep_state", 0);
        PlayerRigid.velocity = new Vector2(0, PlayerRigid.velocity.y);
    }
    #endregion

    public void ShootBullets()
    {
        sfx.player_shoot.Play();
        Instantiate(Bullet, transform.position, transform.rotation);
    }

    #region "Collision and Triggers"
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EndLevel")
        {
            SceneManager.LoadScene("menu");
        }

        if(collision.gameObject.tag == "LevelDeath")
        {
            OnPlayerDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            GameData.playerGrounded = true;
            PlayerAnimator.SetInteger("sheep_state", 0);
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            GameUI.ShowDiamondCounter();
            GameData.playerCoins++;
            GameData.playerScore += 50;
            sfx.coin_get.Play();
        }

        if(collision.gameObject.tag == "BossBattleTrigger")
        {
            GameData.bossBattleStarted = true;
        }
        if (collision.gameObject.tag == "BossOffTrigger")
        {
            GameData.bossBattleStarted = false;
        }

        if (collision.gameObject.tag == "BiscuitPower") //En d of Level
        {
            StartCoroutine(GameUI.FadeMenuCompleted());
            PlayerRigid.constraints = RigidbodyConstraints2D.FreezeAll;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            GameData.playerGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            OnPlayerDeath();
        }
        if(collision.gameObject.tag == "Fireball")
        {
            OnPlayerDeath();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "MovingPlatform")
        {
            onMovingPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            onMovingPlatform = false;
        }
    }
    #endregion

    #region "Save Game Data"
    void OnPlayerDeath()
    {
        GameData.leftMovementPressed = false;
        GameData.rightMovementPressed = false;
        sfx.player_hit.Play();
        PlayerSprite.flipY = true;
        PlayerPrefs.SetInt("PLAYER_COINS", GameData.playerCoins);
        GameData.playerAlive = false;
        StartCoroutine(GameUI.FadeMenuGameOver());
    }
    #endregion
}
