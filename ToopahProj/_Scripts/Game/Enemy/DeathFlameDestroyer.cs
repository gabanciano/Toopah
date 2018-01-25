using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFlameDestroyer : MonoBehaviour {

    float deleteDelayTime = 1f;

	void Update () {
        deleteDelayTime -= Time.deltaTime;
        if(deleteDelayTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
