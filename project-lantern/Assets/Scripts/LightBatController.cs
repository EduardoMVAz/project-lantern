using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBatController : MonoBehaviour
{
    [SerializeField] private GameObject levelManager;
    //private Light2D lighty;
    private Animator anim;
    [SerializeField] private float speed;

    [SerializeField] private List<Vector3> moveCoordinates;
    private int idxCurrCoord = 0;
    private bool goingForwards;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        goingForwards = true;
        SetIsMoving(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            Move();
        }
        // if the coordinates of the enemy are the same as the current coordinates, move to the next coordinates
        if (transform.position.x == moveCoordinates[idxCurrCoord][0] && transform.position.y == moveCoordinates[idxCurrCoord][1]) {
            if (goingForwards) {
                idxCurrCoord++;
            } else {
                idxCurrCoord--;
            }
            if (idxCurrCoord == moveCoordinates.Count) {
                goingForwards = false;
                idxCurrCoord -= 2;
            } else if (idxCurrCoord == -1) {
                goingForwards = true;
                idxCurrCoord += 2;
            }
            SetIsMoving(false);
        }        
    }

    private void Move() {
        // move the enemy to the next coordinates
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(moveCoordinates[idxCurrCoord][0], moveCoordinates[idxCurrCoord][1], 0), speed * Time.deltaTime);
    }

    public void SetIsMoving(bool state) {
        isMoving = state;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "kabu" && !other.gameObject.GetComponent<KabuController>().GetIsHidden()) {
            // if the light bat collides with the kabu, the light bat will be hidden
            this.gameObject.SetActive(false);
        }
    }
}
