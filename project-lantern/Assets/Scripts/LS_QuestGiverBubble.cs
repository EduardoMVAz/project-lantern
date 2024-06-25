using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LS_questGiverBubble : MonoBehaviour
{
    [SerializeField] private float timerLimit;
    [SerializeField] private GameObject bubble;
    private bool playerInside = false;
    private int index = 0;
    private int lastIndex;
    private float timer;

    void Start() {
        timer = timerLimit;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside) {
            bubble.SetActive(true);

        } else {
            bubble.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        playerInside = false;
    }
}
