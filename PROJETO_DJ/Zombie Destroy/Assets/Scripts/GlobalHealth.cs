using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GlobalHealth : MonoBehaviour
{

    public static int currentHealth = 20;
    public static int internalHealth;
    public GameObject healthDisplay;

    void Update()
    {
        internalHealth = currentHealth;
        healthDisplay.GetComponent<Text>().text = "" + currentHealth;

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(5);
            currentHealth = 20;
            GlobalAmmo.AmmoCount = 0;
        }
    }
}
