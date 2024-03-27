using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 3;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask obstacleMask;

    private Animator anim;

    void Start() {
        movePoint.parent = null; // Detach partent
        anim = GetComponent<Animator>();
    }

    void Update() {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);

        if (Vector3.Distance(transform.position, movePoint.position) == 0.0f) {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, obstacleMask)) {
                    Move(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));
                }
            } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, obstacleMask)) {
                    Move(new Vector3(0, Input.GetAxisRaw("Vertical"), 0));
                }
            }
            anim.SetBool("moving", false);
        } else {
            anim.SetBool("moving", true);
        }
    }

    private void Move(Vector3 direction) {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask)) {
            movePoint.position = newPosition;
        }
    }
}
