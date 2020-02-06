using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool IsFiring = false;
    public float targetDistance;
    public int DamageAmount = 5;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GlobalAmmo.AmmoCount>=1)
        {
            if (IsFiring == false)
            {
                GlobalAmmo.AmmoCount -= 1;
                StartCoroutine(FiringPistol());
            }
        }

    }

    IEnumerator FiringPistol()
    {
        RaycastHit Shot;//Shot variable
        
        IsFiring = true;
        if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out Shot))
        {
            targetDistance = Shot.distance;
            Shot.transform.SendMessage("DamageZombie", DamageAmount, SendMessageOptions.DontRequireReceiver);
        }
        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        IsFiring = false;
    }
}
