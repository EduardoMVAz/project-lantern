using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour {

    public bool inMenu;

    [SerializeField] private float speed = 3;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask obstacleMask;

    private Light2D lighty;
    private Animator anim;
    private bool walked = false;

    void Start() {
        movePoint.parent = null; // Detach partent
        anim = GetComponent<Animator>();
        lighty = GetComponent<Light2D>(); // control the light like this!
        inMenu = false;
    }

    void Update() {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

        if (!inMenu) {
            if (Vector3.Distance(transform.position, movePoint.position) == 0.0f) {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >= 0.9f) {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, obstacleMask) && walked == false) {
                        Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                        walked = true;
                        lighty.color = Color.red;
                    }
                } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) >= 0.9f) {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, obstacleMask) && walked==false) {
                        Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                        walked = true;
                        lighty.color = Color.red;
                    }
                }
                anim.SetBool("moving", false);
            } else {
                anim.SetBool("moving", true);
            }

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.5f) {
                walked = false;
                lighty.color = Color.yellow;
            }

        } // outside here would be while in-menu
    }

    private void Move(Vector3 direction) {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {
            movePoint.position = newPosition;
        }
    }
}
