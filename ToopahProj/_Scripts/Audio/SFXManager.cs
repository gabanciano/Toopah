using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    [Header("Game")]
    public AudioSource coin_get;
    public AudioSource one_up_get;
    [Space]
    
    [Header("Player")]
    public AudioSource player_jump;
    public AudioSource player_hit;
    public AudioSource player_death;
    public AudioSource player_shoot;

    [Header("Bullet")]
    public AudioSource bullet_collide;
}
