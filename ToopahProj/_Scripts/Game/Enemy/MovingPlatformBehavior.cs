using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehavior : MonoBehaviour {

    public float movementSpeed;
    public float movementTimeSet;

    float movementTime;

    public bool changeDirection;

    Rigidbody2D EnemyRigid;

    void InitEnemyData()
    {
        movementTime = movementTimeSet;
        EnemyRigid = GetComponent<Rigidbody2D>();
        changeDirection = true;
    }

    void Start()
    {
        InitEnemyData();
    }

    void Update()
    {
        if (changeDirection)
        {
            EnemyRigid.velocity = new Vector2(movementSpeed, EnemyRigid.velocity.y);

        }
        else if (!changeDirection)
        {
            EnemyRigid.velocity = new Vector2(-movementSpeed, EnemyRigid.velocity.y);
        }

        movementTime -= Time.deltaTime;
        if (movementTime <= 0)
        {
            if (changeDirection)
            {
                changeDirection = false;
            }
            else if (!changeDirection)
            {
                changeDirection = true;
            }
            movementTime = movementTimeSet;
        }
    }
}
