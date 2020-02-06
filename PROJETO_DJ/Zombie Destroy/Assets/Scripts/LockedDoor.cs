using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LockedDoor : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
    public AudioSource lockedDoor;
    public AudioSource unlockedDoor;
    public GameObject FadeOutScreen;



    // Update is called once per frame
    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 2)
        {
            ExtraCross.SetActive(true);
            ActionText.GetComponent<Text>().text = "Open Door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                if (KeyPickUp.gotKey == true)
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    StartCoroutine(fadeExit());
                }
                else
                {
                    this.GetComponent<BoxCollider>().enabled = false;
                    ActionDisplay.SetActive(false);
                    ActionText.SetActive(false);
                    ExtraCross.SetActive(false);
                    StartCoroutine(DoorReset());
                }

            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }

    IEnumerator DoorReset()
    {
        lockedDoor.Play();
        yield return new WaitForSeconds(1);
        this.GetComponent<BoxCollider>().enabled = true;
    }
    IEnumerator fadeExit()
    {
        unlockedDoor.Play();
        FadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(6);
    }
}
