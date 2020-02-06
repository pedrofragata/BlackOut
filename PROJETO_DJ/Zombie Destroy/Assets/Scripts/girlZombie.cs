using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class girlZombie : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject fadeOut;
    public float enemySpeed = 0.00000000000000001f;
    public bool attackTrigger = false;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform);
        if (attackTrigger == false)
        {
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(4.033f);
        transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, enemySpeed);
        yield return new WaitForSeconds(3);
        enemySpeed = 0;
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(8);

    }
}
