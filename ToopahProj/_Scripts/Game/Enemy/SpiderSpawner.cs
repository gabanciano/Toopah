using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour {

    public GameObject Spiderling;

    float spawnDelay = 5f;
    float spawnInterval = 6f;

	void Start () {
		
	}
	
	void Update () {
        if (GameData.bossBattleStarted)
        {
            spawnInterval -= Time.deltaTime;
            if (spawnInterval <= 0)
            {
                Instantiate(Spiderling, new Vector3(Random.Range(168f, 205f), transform.position.y), transform.rotation);
                Instantiate(Spiderling, new Vector3(Random.Range(168f, 205f), transform.position.y), transform.rotation);
                spawnInterval = 6f;
            }
        }
       
	}
}
