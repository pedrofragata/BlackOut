using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillingSequence : MonoBehaviour
{
    public GameObject subtitleText;
    public GameObject fadeOut;
    public AudioSource fire;
    public AudioSource girlMoan;
    public AudioSource sorry;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LastScene());
    }
    
    IEnumerator LastScene()
    {
        yield return new WaitForSeconds(3);
        fadeOut.SetActive(true);
        subtitleText.SetActive(true);
        sorry.Play();
        subtitleText.GetComponent<Text>().text = "Sorry Sophie";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1.3f);
        fire.Play();
        girlMoan.Stop();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(10);
    }
}
