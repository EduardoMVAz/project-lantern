using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class PlayerController : MonoBehaviour {

    public bool inMenu;

    [SerializeField] private GameObject levelManager;

    [SerializeField] private TextMeshProUGUI remainingLightText;
    [SerializeField] private float speed = 3;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask obstacleMask;
    [SerializeField] private List<int> lightThresholds;
    private int currentThreshold = 0;
    private Light2D lighty;
    private Animator anim;

    public bool canMove = false;
    private bool walked = false;
    private bool isDead = false;
    private string deathCause;
    private bool won = false;

    private int moveAmount;
    private int moveAmountMax;
    private int moveCost = 1;

    void Start() {
        movePoint.parent = null; // Detach partent
        anim = GetComponent<Animator>();
        lighty = GetComponent<Light2D>(); // control the light like this!
        inMenu = false;

        moveAmountMax = levelManager.GetComponent<LevelManager>().GetMoveAmount();
        moveAmount = moveAmountMax;
        SetRemainingLightText();
    }

    void Update() {

        if (!canMove) {
            canMove = levelManager.GetComponent<LevelManager>().GetCanMove();
        }

        if (inMenu || !canMove || isDead || won) {
            return;
        }

        float movementAmount = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmount);

        if (Vector3.Distance(transform.position, movePoint.position) == 0.0f) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= 0.9f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, obstacleMask) && walked == false) {
                    Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                    walked = true;
                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) >= 0.9f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, obstacleMask) && walked==false) {
                    Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                    walked = true;
                }
            }
            anim.SetBool("moving", false);
        } else {
            anim.SetBool("moving", true);
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.5f) {
            walked = false;
        }
    }

    private void Move(Vector3 direction) {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {
            movePoint.position = newPosition;
            moveAmount -= moveCost;

            // Update the light
            if (moveAmount > 0) {
                UpdateLight();
            } else {
                UpdateLight();
                isDead = true;
                deathCause = "light";
            }

            levelManager.GetComponent<LevelManager>().MoveEnemies();

            SetRemainingLightText();
        }
    }

    // detect collision with roughGround tag
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag.Equals("roughGround")) {
            moveCost = 2;
        }
      
        if (other.tag.Equals("goal")) {
            won = true;
        }
      
        if (other.gameObject.tag.Equals("extraLight")) {
            moveAmount += 5;
            if (moveAmount > moveAmountMax) {
                moveAmount = moveAmountMax;
            }
            SetRemainingLightText();
            Destroy(other.gameObject);
        }

        if (other.tag.Equals("lightBat")) {
            isDead = true;
            deathCause = "enemy";
        }

        if (other.gameObject.tag.Equals("kabu") && !other.gameObject.GetComponent<KabuController>().GetIsHidden()) {
            isDead = true;
            deathCause = "enemy";
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag.Equals("roughGround")) {
            moveCost = 1;
        }
    }

    private void UpdateLight() { 
        if (currentThreshold < lightThresholds.Count && moveAmount < lightThresholds[currentThreshold]) {
            currentThreshold++;
            lighty.pointLightOuterRadius -= 2;
        }
    }

    private void SetRemainingLightText() {
        remainingLightText.text = "Remaining Light: " + moveAmount + " / " + moveAmountMax;
    }

    public bool GetIsDead() {
        return isDead;
    }

    public string GetDeathCause() {
        return deathCause;
    }

    public bool GetWon() {
        return won;
    }

    public int GetMoveAmount() {
        return moveAmount;
    }
}
