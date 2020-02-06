using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CutSceneSequence : MonoBehaviour
{
    public GameObject subtitleText;
    public GameObject girlZombie;
    public GameObject deadBody;
    public AudioSource girlScream;
    public AudioSource girlEating;
    public AudioSource Line01;
    public AudioSource Line02;
    public AudioSource Line03;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        girlZombie.GetComponent<Animation>().Play("Zombie Idle");
        yield return new WaitForSeconds(1);
        subtitleText.SetActive(true);
        Line01.Play();
        subtitleText.GetComponent<Text>().text = "Sophie?";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.5f);
        Line02.Play();
        subtitleText.GetComponent<Text>().text = "Oh No";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        girlZombie.GetComponent<Animation>().Play("Zombie Biting");
        yield return new WaitForSeconds(0.5f);
        girlEating.Play();
        yield return new WaitForSeconds(2);
        Line03.Play();
        subtitleText.GetComponent<Text>().text = "ROSEEEE";
        yield return new WaitForSeconds(1);
        subtitleText.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(4);
        girlEating.Stop();
        deadBody.GetComponent<Animation>().Play("Laying Sleeping");
        girlZombie.GetComponent<Animation>().Play("Zombie Scream 1");
        girlScream.Play();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(7);
    }
    
}
