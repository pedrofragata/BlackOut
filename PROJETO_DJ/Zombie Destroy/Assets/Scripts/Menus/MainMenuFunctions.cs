using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuFunctions : MonoBehaviour
{
    public GameObject fadeOut;
    public GameObject loadingText;
    public GameObject menuOptions;
    public GameObject settingsPanel;
    public AudioSource buttonHit;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None; //Locks the mouse
        Cursor.visible = true; // Make the cursor visable
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(7);
        }
    }
    public void newGameButton()
    {
        StartCoroutine(newGameStart());
    }

    public void settingsButton()
    {
        StartCoroutine(settingsMenu());
    }

    public void returnToMenu()
    {
        buttonHit.Play();
        settingsPanel.SetActive(false);
        menuOptions.SetActive(true);
    }
    public void goToCredits()
    {
        StartCoroutine(goToCredit());
    }
   public void exitGameButton()
    {
        Application.Quit();//Only Works in the .exe file
    }
    IEnumerator newGameStart()
    {
        fadeOut.SetActive(true);
        buttonHit.Play();
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        SceneManager.LoadScene(2);
    }

    IEnumerator settingsMenu()
    {
        buttonHit.Play();
        menuOptions.SetActive(false);
        settingsPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator goToCredit()
    {
        buttonHit.Play();
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(3);
        loadingText.SetActive(true);
        SceneManager.LoadScene(10);
    }

    
}
