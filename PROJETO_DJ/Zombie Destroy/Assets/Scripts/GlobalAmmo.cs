using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalAmmo : MonoBehaviour
{
    public static int AmmoCount;
    public GameObject AmmoDisplay;
    public static int Ammo;
 
    void Update()
    {
        Ammo = AmmoCount;
        AmmoDisplay.GetComponent<Text>().text = "" + AmmoCount;
        Debug.Log("Ammo" + AmmoCount);

    }
}
