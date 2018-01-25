using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosionBehavior : MonoBehaviour {

    float objectLifeTime = 0.25f;

    private void Update()
    {
        objectLifeTime -= Time.deltaTime;
        if(objectLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
