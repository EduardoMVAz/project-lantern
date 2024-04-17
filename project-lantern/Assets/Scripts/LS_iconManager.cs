using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_iconManager : MonoBehaviour {

    public GameObject[] levelButtons;
    public GameObject[] levelFlies;
    public Sprite[] sprites;

    void Start() {
        
        for (int i = 0; i < levelButtons.Length; i++) {
            int index = PlayerPrefs.GetInt("Level " + i.ToString(), 0);
            levelButtons[i].GetComponent<Image>().sprite = sprites[index];
            levelFlies[i].SetActive(false);
        }
        StartCoroutine(ActivateLights());
    }

    IEnumerator ActivateLights() {
        for (int i = 0; i < levelFlies.Length; i++) {
            int index = PlayerPrefs.GetInt("Level " + i.ToString(), 0);
            if (index != 0) {
                levelFlies[i].SetActive(true);
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
