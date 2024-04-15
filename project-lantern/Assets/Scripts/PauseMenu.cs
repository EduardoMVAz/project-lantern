using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button resumeButton, menuButton, exitButton;
    [SerializeField] private GameObject pauseFirst;
    
    private GameObject paused;

    public void Start() {
        pauseMenu.SetActive(false);
        resumeButton.onClick.AddListener(() => CloseMenu());
        menuButton.onClick.AddListener(() => LoadMenu());
        exitButton.onClick.AddListener(() => Exit());
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
            if (paused) {
                CloseMenu();
            } else {
                pauseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseFirst);
            }
        }
    }

    public void CloseMenu() {
        pauseMenu.SetActive(false);
    }

    public void LoadMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit() {
        Application.Quit();
    }
}
