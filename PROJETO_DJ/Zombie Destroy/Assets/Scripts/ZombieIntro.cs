using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIntro : MonoBehaviour
{
    public static float speed=-0.05f;
    public static bool startRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(letZombieMove());
    }

    // Update is called once per frame
    void Update()
    {
        if (startRunning)
        {
            this.transform.Translate(transform.forward* speed);
        }
    }

    IEnumerator letZombieMove()
    {
        yield return new WaitForSeconds(20.0f);
        startRunning = true;
    }
}
