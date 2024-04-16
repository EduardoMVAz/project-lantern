using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.Universal;
using TMPro;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private int moveAmount;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject deadText;
    [SerializeField] private GameObject wonText;
    [SerializeField] private Light2D initialLight;
    [SerializeField] private int perfection;
    private float initialLightCountdown = 5.0f;
    private bool canMove = false;
    private bool isDead = false;
    private string deathCause;
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
            deathCause = player.GetComponent<PlayerController>().GetDeathCause();
        }

        if (!won) {
            won = player.GetComponent<PlayerController>().GetWon();
        }

        // Game end 
        if (isDead) {
            ManageDeath(deathCause);
        }

        if (won) {
            ManageVictory();
        }
    }

    public void MoveEnemies() {
        ManageKabus();
        ManageLightBats();
    }

    private void ManageDeath(string cause) {
        transitionTime -= Time.deltaTime;
        if (cause.Equals("enemy")) {
            deadText.GetComponent<TextMeshProUGUI>().text = "You Lost your Light...";
        } else if (cause.Equals("light")) {
            deadText.GetComponent<TextMeshProUGUI>().text = "You Ran out of Light...";
        }
        deadText.SetActive(true);
        if (transitionTime < 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ManageVictory() {
        transitionTime -= Time.deltaTime;
        wonText.SetActive(true);
        if (player.GetComponent<PlayerController>().GetMoveAmount() >= perfection) {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 2); // perfection!
        } else if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) <= 1) {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1); // you beat it :D
        }
        if (transitionTime < 0) SceneManager.LoadScene("LevelSelect");
    }

    public void ManageKabus() {
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("kabu");

        foreach (GameObject kabu in prefabInstances) {
            kabu.GetComponent<KabuController>().ChangeState();
        }
    }

    public void ManageLightBats() {
        GameObject[] prefabInstances = GameObject.FindGameObjectsWithTag("lightBat");

        foreach (GameObject lightbat in prefabInstances) {
            lightbat.GetComponent<LightBatController>().SetIsMoving(true);
        }
    }
}
