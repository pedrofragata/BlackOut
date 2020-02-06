using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DoorCellOpenExit : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionDisplay;
    public GameObject ActionText;
    public GameObject ExtraCross;
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
            ActionText.GetComponent<Text>().text = "Open Door";
            ActionDisplay.SetActive(true);
            ActionText.SetActive(true);
            ExtraCross.SetActive(true);

        }
        else
        {
            ActionDisplay.SetActive(false);
            ActionText.SetActive(false);
            ExtraCross.SetActive(false);
        }
        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 2)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                ActionDisplay.SetActive(false);
                ActionText.SetActive(false);
                StartCoroutine(fadeExit());
            }
        }
    }

    void OnMouseExit()
    {
        ExtraCross.SetActive(false);
        ActionDisplay.SetActive(false);
        ActionText.SetActive(false);
    }
    IEnumerator fadeExit()
    {
        FadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(4);
    }
}
