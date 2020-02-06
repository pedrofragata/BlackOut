using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalSceneSequence : MonoBehaviour
{
    public GameObject subtitleText;
    public GameObject deadBody;
    public AudioSource Line01;
    public AudioSource Line02;
    public AudioSource Line03;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sceneSequence());
    }

    IEnumerator sceneSequence()
    {
        yield return new WaitForSeconds(0.5f);
        deadBody.GetComponent<Animation>().Play("Laying Sleeping");
        subtitleText.SetActive(true);
        Line01.Play();
        subtitleText.GetComponent<Text>().text = "Sophie";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        Line02.Play();
        subtitleText.GetComponent<Text>().text = "Please Stop";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1);
        Line03.Play();
        subtitleText.GetComponent<Text>().text = "I can't";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
    }
}
