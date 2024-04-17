using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton, levelSelectButton, menuButton, exitButton;
    public GameObject player;

    [SerializeField] private GameObject pauseFirst;
    private PlayerController playerController;
    private bool paused;

    public void Start() {
        pauseMenu.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
        resumeButton.onClick.AddListener(() => CloseMenu());
        levelSelectButton.onClick.AddListener(() => LoadLevelSelect());
        menuButton.onClick.AddListener(() => LoadMenu());
        exitButton.onClick.AddListener(() => Exit());
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (paused) {
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

    public void LoadLevelSelect() {
        SceneManager.LoadScene("LevelSelect");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit() {
        Application.Quit();
    }
}
