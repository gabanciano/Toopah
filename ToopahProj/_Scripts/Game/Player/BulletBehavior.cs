using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour {

    [Header("Enemy Death Animation")]
    public GameObject EnemyDeathFlame;
    public GameObject BulletExplosion;
    [Space]

    float bulletLifeTime = 0.5f;
    public float bulletSpeed;
    bool playerDirection;

    Rigidbody2D BulletRigid;

    private void Start()
    {
        BulletRigid = GetComponent<Rigidbody2D>();
        playerDirection = GameData.playerDirLeft;
    }

    private void Update()
    {
        MoveBullet();
        ChangeBulletDirection();
        DestroyBullet();
    }

    void MoveBullet()
    {
        if (playerDirection)
        {
            BulletRigid.velocity = new Vector2(-bulletSpeed, 0);
        }
        else if (!playerDirection)
        {
            BulletRigid.velocity = new Vector2(bulletSpeed, 0);
        }
    }

    void ChangeBulletDirection()
    {
        if (playerDirection)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if (!playerDirection)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void DestroyBullet()
    {
        bulletLifeTime -= Time.deltaTime;
        if(bulletLifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Instantiate(EnemyDeathFlame, new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y + 0.3f, collision.gameObject.transform.position.z), collision.gameObject.transform.rotation);
            GameData.playerScore += 250;
        }
        Instantiate(BulletExplosion, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
