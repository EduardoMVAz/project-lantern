using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private int moveAmount;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deadText;
    [SerializeField] private GameObject wonText;
    [SerializeField] private Light2D initialLight;
    private float initialLightCountdown = 5.0f;
    private bool canMove = false;
    private bool isDead = false;
    private bool won = false;
    private float transitionTime = 2;

    public int GetMoveAmount() {
        return moveAmount;
    }

    public bool GetCanMove() {
        return canMove;
    }

    // Update is called once per frame
    void Update()
    {
        // Initial Light shenanigans
        if (initialLightCountdown > 0) {
            initialLightCountdown -= Time.deltaTime;
            initialLight.intensity = initialLightCountdown / 10;
        }
        if (initialLightCountdown <= 0 && !canMove) {
            initialLight.intensity = 0.0f;
            canMove = true;
        }

        if (!isDead) {
            isDead = player.GetComponent<PlayerController>().GetIsDead();
        }

        if (!won) {
            won = player.GetComponent<PlayerController>().GetWon();
        }

        // Game end 
        if (isDead) {
            ManageDeath();
        }

        if (won) {
            ManageVictory();
        }
    }

    private void ManageDeath() {
        transitionTime -= Time.deltaTime;
        deadText.SetActive(true);
        if (transitionTime < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ManageVictory() {
        transitionTime -= Time.deltaTime;
        wonText.SetActive(true);
        if (transitionTime < 0) SceneManager.LoadScene("LevelSelect");
    }
}
