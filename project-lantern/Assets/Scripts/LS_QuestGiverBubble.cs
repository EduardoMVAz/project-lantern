using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LS_questGiverBubble : MonoBehaviour
{
    [SerializeField] private float timerLimit;
    [SerializeField] private GameObject[] bubbles;
    private bool playerInside = false;
    private int index = 0;
    private int lastIndex;
    private float timer;

    void Start() {
        for (int i = 0; i < bubbles.Length; i++) {
            bubbles[i].SetActive(false); 
        }
        timer = timerLimit;
        lastIndex = bubbles.Length-1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside) {
            timer -=  Time.deltaTime * 5;
            if (timer <= 0.0f) {
                timer = timerLimit;

                // moves to the next text bubble
                index++;
                if (index >= bubbles.Length) {
                    index = 0;
                }
                lastIndex++;
                if (lastIndex >= bubbles.Length) {
                    lastIndex = 0;
                }
            }
            // switches bubble
            bubbles[index].SetActive(true);
            bubbles[lastIndex].SetActive(false);

        } else {
            bubbles[index].SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        playerInside = false;
    }
}
