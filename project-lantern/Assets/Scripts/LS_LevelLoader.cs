using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Analytics;
using UnityEngine.Rendering.Universal;
using static Unity.Collections.AllocatorManager;

public class LevelLoader : MonoBehaviour
{
    public Button level1, level2, level3, level4, level5, level6, level7, level8, level9, level10;
    public TextMeshProUGUI levelText;
    public GameObject blocker;

    private string levelSelected = "locked";
    private Light2D lighty;

    void Start()
    {
        lighty = GetComponent<Light2D>();
        lighty.enabled = false;
        blocker.SetActive(true);

        level1.onClick.AddListener(() => ChangeLevelSelected("Level 1"));
        level2.onClick.AddListener(() => ChangeLevelSelected("Level 2"));
        level3.onClick.AddListener(() => ChangeLevelSelected("Level 3"));
        level4.onClick.AddListener(() => ChangeLevelSelected("Level 4"));
        level5.onClick.AddListener(() => ChangeLevelSelected("Level 5"));
        level6.onClick.AddListener(() => ChangeLevelSelected("Level 6"));
        level7.onClick.AddListener(() => ChangeLevelSelected("Level 7"));
        level8.onClick.AddListener(() => ChangeLevelSelected("Level 8"));
        level9.onClick.AddListener(() => ChangeLevelSelected("Level 9"));
        level10.onClick.AddListener(() => ChangeLevelSelected("Level 10"));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (levelSelected != "locked") {
            SceneManager.LoadScene(levelSelected);
        }
    }

    void ChangeLevelSelected(string newLevel) {
        lighty.enabled = true;
        blocker.SetActive(false);
        levelSelected = newLevel;
        levelText.text = newLevel;
        if (levelText.text == "Level 0") {
            levelText.text = "Tutorial";
        }
    }
}
