using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class getEating : MonoBehaviour
{
    public  GameObject SubtitleText;
    public GameObject fadeOutScreen;
    public AudioSource Scream;
    private void Start()
    {
        StartCoroutine(getEat());
    }

    IEnumerator getEat()
    {
        yield return new WaitForSeconds(0.5f);
        SubtitleText.SetActive(true);
        Scream.Play();
        SubtitleText.GetComponent<Text>().text = "NOOOO";
        yield return new WaitForSeconds(1);
        SubtitleText.GetComponent<Text>().text = "";
        fadeOutScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(10);
    }
}
