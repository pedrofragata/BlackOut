using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirePistol1 : MonoBehaviour
{
    public GameObject TheGun;
    public GameObject MuzzleFlash;
    public AudioSource GunFire;
    public bool alrdyShot= false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (alrdyShot == false)
            {
                StartCoroutine(FiringPistol());
            }
        }

    }

    IEnumerator FiringPistol()
    {
        
        alrdyShot = true;

        TheGun.GetComponent<Animation>().Play("PistolShot");
        MuzzleFlash.SetActive(true);
        MuzzleFlash.GetComponent<Animation>().Play("MuzzleAnim");
        GunFire.Play();
        yield return new WaitForSeconds(0.1f);
        MuzzleFlash.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(9);
    }
}
