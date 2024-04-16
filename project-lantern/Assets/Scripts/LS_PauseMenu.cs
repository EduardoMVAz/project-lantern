using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LS_PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton, menuButton, exitButton;
    public GameObject player;

    [SerializeField] private GameObject pauseFirst;
    private PlayConLevelSelect playerController;
    private bool paused;

    public void Start() {
        pauseMenu.SetActive(false);
        playerController = player.GetComponent<PlayConLevelSelect>();
        resumeButton.onClick.AddListener(() => CloseMenu());
        menuButton.onClick.AddListener(() => LoadMenu());
        exitButton.onClick.AddListener(() => Exit());
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel") ) {
            if (playerController.inMenu == true && paused == false) {
                // huh, the player was in the quest menu then!
            } else if (paused) {
                CloseMenu();
            } else {
                playerController.inMenu = true;
                pauseMenu.SetActive(true);
                paused = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseFirst);
            }
        }
    }

    public void CloseMenu() {
        playerController.inMenu = false;
        pauseMenu.SetActive(false);
        paused = false;
    }

    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit() {
        Application.Quit();
    }
}
