using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class FSMachine : MonoBehaviour
{
    public GameState curGameState;
    public GameObject pauseMenu;
    public GameObject player;
    public GameObject zombie;
    public AudioSource buttonHit;
    public GameObject settingsPanel;
    public GameObject weapon;

    void Start()
    {
        SetGameState(GameState.Game); 
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetGameState(GameState.pause);
        }
    }
    public void resumeButton()
    {
        SetGameState(GameState.Game);
    }

    public void SetGameState(GameState _state)
    {
        // if our current game state is the same of our target state...
        if (curGameState == _state)
        {
            // ...we exit from the method and don't do anything
            return;
        }

        // we update our state...
        curGameState = _state;

        // ...and now check what this new state will do to our game and apply the changes
        switch (curGameState)
        {
            case GameState.Game:
                resumeGame();
                break;

            case GameState.pause:
                pauseGame();
                break;

            case GameState.GameOver:
                OnGameOver();
                break;
        }
    }

    private void OnGameOver()
    {
        SceneManager.LoadScene(5);
    }

    private void pauseGame()
    {
       player.GetComponent<FirstPersonController>().enabled = false;
        weapon.GetComponent<FirePistol>().enabled = false;
        zombie.GetComponent<ZombieAI>().enabled = false;
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None; //Locks the mouse
        Cursor.visible = true; // Make the cursor visable
        Time.timeScale = 0; // Stop world moving
    }
    
    private void resumeGame()
    {
        player.GetComponent<FirstPersonController>().enabled = true;
        weapon.GetComponent<FirePistol>().enabled = true;

        zombie.GetComponent<ZombieAI>().enabled = true;
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked; //Locks the mouse
        Cursor.visible = false; // Make the cursor visable
        Time.timeScale = 1; // Stop world moving

    }

    public void settingsButton()
    {
        StartCoroutine(settingsMenu());
    }

    public void ExitGameButton()
    {
        Application.Quit(); //Only Works in the .exe
    }

    IEnumerator settingsMenu()
    {
        buttonHit.Play();
        pauseMenu.SetActive(false);
        settingsPanel.SetActive(true);
        yield return new WaitForSeconds(0.1f);
    }

    public void returnToMenu()
    {
        buttonHit.Play();
        settingsPanel.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
