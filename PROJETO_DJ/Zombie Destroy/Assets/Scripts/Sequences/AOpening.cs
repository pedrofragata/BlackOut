using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;
public class AOpening : MonoBehaviour
{
    public GameObject ThePlayer;
    public GameObject FadeScreenIn;
    public GameObject TextBox;
    public AudioSource line01;

    void Start()
    {
        ThePlayer.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(ScenePlayer());
    }

    IEnumerator ScenePlayer()
    {
        yield return new WaitForSeconds(1.5f);
        FadeScreenIn.SetActive(false);
        TextBox.GetComponent<Text>().text = "Where am I?";
        line01.Play();
        yield return new WaitForSeconds(3);
        TextBox.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        TextBox.GetComponent<Text>().text = "I need to get out of here. I need to save my family";
        yield return new WaitForSeconds(3.5f);
        TextBox.GetComponent<Text>().text = "";
        ThePlayer.GetComponent<FirstPersonController>().enabled = true;

    }
}
