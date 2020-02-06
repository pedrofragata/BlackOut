using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    public GameObject AmmoPanel;
    void OnTriggerEnter(Collider other)
    {
        if (!AmmoPanel.activeSelf)
        {
            AmmoPanel.SetActive(true);
        }
        GlobalAmmo.AmmoCount += 7;
        this.gameObject.SetActive(false);
    }
}
