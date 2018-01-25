using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolfBehavior : MonoBehaviour {

    public GameObject Fireball;

    float throwDelay = 3f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        throwDelay -= Time.deltaTime;
        if(throwDelay <= 0)
        {
            ThrowFireball();
            throwDelay = 3f;
        }
	}

    void ThrowFireball()
    {
        Instantiate(Fireball, transform.position, transform.rotation);
        Instantiate(Fireball, transform.position, transform.rotation);
        Instantiate(Fireball, transform.position, transform.rotation);
    }
}
