using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballExplosionDestroyer : MonoBehaviour {

    float explosionLifeTime = 0.25f;
    void Update()
    {
        explosionLifeTime -= Time.deltaTime;
        if(explosionLifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
