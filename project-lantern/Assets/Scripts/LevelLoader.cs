using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public Button level0, level1, level2, level3, level4;
    public TextMeshProUGUI levelText;
    public string levelSelected = "level0";

    void Start()
    {
        level0.onClick.AddListener(() => ChangeLevelSelected("Level 0"));
        level1.onClick.AddListener(() => ChangeLevelSelected("Level 1"));
        level2.onClick.AddListener(() => ChangeLevelSelected("Level 2"));
        level3.onClick.AddListener(() => ChangeLevelSelected("Level 3"));
        level4.onClick.AddListener(() => ChangeLevelSelected("Level 4"));
    }

    void OnTriggerEnter2D(Collider2D other) {
        SceneManager.LoadScene(levelSelected);
    }

    void ChangeLevelSelected(string newLevel) {
        levelSelected = newLevel;
        levelText.text = newLevel;
    }
}
