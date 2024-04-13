using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private int moveAmount;
    [SerializeField] private Light2D initialLight;
    private float initialLightCountdown = 3.0f;
    private bool canMove = false;

    public int GetMoveAmount() {
        return moveAmount;
    }

    public bool GetCanMove() {
        return canMove;
    }

    // Update is called once per frame
    void Update()
    {
        initialLightCountdown -= Time.deltaTime;
        if (initialLightCountdown <= 0) {
            initialLight.intensity = 0.0f;
            canMove = true;
        }
    }
}
