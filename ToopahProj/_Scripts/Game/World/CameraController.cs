using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Camera BossCamera;

    public GameObject Player;
    private Vector3 offset;
    void Start()
    {
        offset = MainCamera.transform.position - Player.transform.position;
    }
    
    void Update()
    {
        CameraFollowPlayer();
        CheckBossBattle();
    }

    void CameraFollowPlayer()
    {
        MainCamera.transform.position = new Vector3(Player.transform.position.x + offset.x, 2.5f, offset.z);
    }

    void CheckBossBattle()
    {
        if (GameData.bossBattleStarted)
        {
            BossCamera.gameObject.SetActive(true);
            MainCamera.gameObject.SetActive(false);
        }
        else if (!GameData.bossBattleStarted)
        {
            BossCamera.gameObject.SetActive(false);
            MainCamera.gameObject.SetActive(true);
        }
    }
}
