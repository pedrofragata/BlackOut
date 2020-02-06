using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class ZombieAI5 : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject theEnemy;
    public float enemySpeed = 0.02f;
    public bool attackTrigger = false;
    public bool isAttacking = false;
    public AudioSource HurtSound1;
    public AudioSource HurtSound2;
    public AudioSource HurtSound3;
    public int HurtGen;
    public GameObject FlashHurt;
    public GameObject postProcessing;
    public bool isNear = false;
    //Falta mudar a luz quando sofre dano
    void Update()
    {   
        if(thePlayer.transform.position.x < -27 && thePlayer.transform.position.z > 48 && thePlayer.transform.position.z < 50)
        {
            isNear = true;
        }

        if (isNear)
        {
            transform.LookAt(thePlayer.transform);
            if (attackTrigger == false)
            {
                enemySpeed = 0.02f;
                theEnemy.GetComponent<Animation>().Play("Z_Walk_InPlace");
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
            }
            if (attackTrigger == true && isAttacking == false)
            {
                enemySpeed = 0;
                theEnemy.GetComponent<Animation>().Play("Z_Attack");
                StartCoroutine(InflictDamage());
            }
        }
        

    }

    void OnTriggerEnter()
    {
        attackTrigger = true;
    }

    void OnTriggerExit()
    {
        attackTrigger = false;
    }


    IEnumerator InflictDamage()
    {
        PostProcessVolume volume = postProcessing.GetComponent<PostProcessVolume>();
        ChromaticAberration chromaticAberrationLayer;
        volume.profile.TryGetSettings(out chromaticAberrationLayer);
        Debug.Log(chromaticAberrationLayer.intensity.value);
        isAttacking = true;
        HurtGen = Random.Range(1, 4);
        if (HurtGen == 1)
        {
            HurtSound1.Play();
        }
        else if (HurtGen == 2)
        {
            HurtSound2.Play();
        }
        else
        {

            HurtSound3.Play();
        }
        FlashHurt.SetActive(true);
        chromaticAberrationLayer.intensity.value += 0.25f;
        GlobalHealth.currentHealth -= 5;

        yield return new WaitForSeconds(0.3f);
        FlashHurt.SetActive(false);
        yield return new WaitForSeconds(1.1f);
        yield return new WaitForSeconds(0.9f);
        isAttacking = false;
    }

}
