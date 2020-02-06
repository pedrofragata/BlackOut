using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDeath7 : MonoBehaviour
{
    public int EnemyHealth = 20;
    public GameObject TheEnemy;
    public int StatusCheck;
    public AudioSource JumpScareMusic;
    public AudioSource BackGroundMusic;

    void DamageZombie(int DamageAmount)
    {
        EnemyHealth -= DamageAmount;
    }




    void Update()
    {
        if (EnemyHealth <= 0 && StatusCheck == 0)
        {
            this.GetComponent<Rigidbody>().Sleep();

            this.GetComponent<ZombieAI7>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            StatusCheck = 2;
            TheEnemy.GetComponent<Animation>().Stop("Z_Walk_InPlace");
            TheEnemy.GetComponent<Animation>().Play("Z_FallingBack");
            JumpScareMusic.Stop();
            BackGroundMusic.Play();
        }
    }
}
