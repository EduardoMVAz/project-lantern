using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_iconManager : MonoBehaviour {

    public GameObject level0, level1, level2, level3, level4, level5, level6, level7, level8, level9, level10;
    public Sprite[] sprites;

    void Start() {
        
        level0.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 0", 0)];
        level1.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 1", 0)];
        level2.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 2", 0)];
        level3.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 3", 0)];
        level4.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 4", 0)];
        level5.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 5", 0)];
        level6.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 6", 0)];
        level7.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 7", 0)];
        level8.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 8", 0)];
        level9.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 9", 0)];
        level10.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("Level 10", 0)];
        
    }
}
