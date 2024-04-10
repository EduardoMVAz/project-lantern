using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class questBoard : MonoBehaviour
{   
    public GameObject keyPopup;
    public GameObject questMenu;
    public GameObject player;
    public GameObject firstLevel;

    private Light2D lighty;
    private bool playerInside = false;
    private bool menuOpen = false;
    private PlayerController playerController;

    void Start()
    {
        keyPopup.SetActive(false);
        questMenu.SetActive(false);
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside) { 
            if(Input.GetButtonDown("Interact")) { 
                if (!menuOpen) {
                    menuOpen=true;
                    playerController.inMenu = true;
                    EventSystem.current.SetSelectedGameObject(firstLevel);

                } else {
                    menuOpen=false;
                    playerController.inMenu = false;
                    EventSystem.current.SetSelectedGameObject(null);
                }
            }
        }

        keyPopup.SetActive(playerInside);
        questMenu.SetActive(menuOpen);
    }

    void OnTriggerEnter2D(Collider2D other) {
        playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        playerInside = false;
    }
}
