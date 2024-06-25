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
    public GameObject littleSkelly;

    private bool playerInside = false;
    private bool menuOpen = false;
    private PlayConLevelSelect playerController;

    [SerializeField] private AudioSource selectSound;
    void Start()
    {
        keyPopup.SetActive(false);
        questMenu.SetActive(false);
        playerController = player.GetComponent<PlayConLevelSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside) {
            if (Input.GetButtonDown("Interact")) {
                if (!menuOpen) {
                    menuOpen = true;
                    playerController.inMenu = true;
                    EventSystem.current.SetSelectedGameObject(firstLevel);
                }
            }
            if (Input.GetButtonDown("Cancel") && menuOpen == true) {
                menuOpen = false;
                playerController.inMenu = false;
                EventSystem.current.SetSelectedGameObject(null);
            }
            if (Input.GetButtonDown("Horizontal")) {
                if (menuOpen) {
                    selectSound.Play();
                }
            }
            if (EventSystem.current.currentSelectedGameObject != null) {
                littleSkelly.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
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
