using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class IntroSequence : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadingText;
    public Camera firstCamera;
    public Camera secondCamera;
    public GameObject subtitleText;
    public AudioSource line01; 
    public AudioSource line02;
    public AudioSource line03;


    void Start()
    {
        StartCoroutine(goToGame());
    }

    IEnumerator goToGame()
    {
        //Any subtitles, voiceacting we want to put in the animation

        //time to the end of the animation
        yield return new WaitForSeconds(20.0f);
        firstCamera.gameObject.SetActive(false);
        secondCamera.gameObject.SetActive(true);
        secondCamera.GetComponent<Animation>().Play("IntroAnim2");
        yield return new WaitForSeconds(5);
        line01.Play();
        yield return new WaitForSeconds(0.5f);
        subtitleText.SetActive(true);
        subtitleText.GetComponent<Text>().text = "Oh no";
        secondCamera.GetComponent<Animation>().Play("IntroAnim3");
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";

        line02.Play();
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "ROSEEEEE!SOPHIEEEEE";
        yield return new WaitForSeconds(3);
        line03.Play();
        subtitleText.GetComponent<Text>().text = "We need to run";
        yield return new WaitForSeconds(1);
        //start the fadeout and load the gamescene
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        subtitleText.GetComponent<Text>().text = "";

        loadingText.SetActive(true);
        SceneManager.LoadScene(3);
    }

}
