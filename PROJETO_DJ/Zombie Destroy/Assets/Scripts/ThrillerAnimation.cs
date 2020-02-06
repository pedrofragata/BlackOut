using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ThrillerAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Thriller());

    }
    void update()
    {
        Debug.Log(transform.position.x);
    }
    
    IEnumerator Thriller()
    {
        yield return new WaitForSeconds(1);
        this.GetComponent<Animation>().Play("Thriller Part 1");
        yield return new WaitForSeconds(30);
        SceneManager.LoadScene(1);
    }

}
