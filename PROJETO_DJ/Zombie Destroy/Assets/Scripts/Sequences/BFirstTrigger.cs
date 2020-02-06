using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;


public class BFirstTrigger : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject TextBox;
    public GameObject TheMarker;
    public AudioSource line03;

    void OnTriggerEnter()
    {
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        TextBox.GetComponent<Text>().text = "Looks like a weapon on that table.";
        line03.Play();
        yield return new WaitForSeconds(2);
        TextBox.GetComponent<Text>().text = "";
        TheMarker.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
