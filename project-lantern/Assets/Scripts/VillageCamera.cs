using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageCamera : MonoBehaviour
{
    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed = 3;
    
    public float targetSize;

    void Start() {
        movePoint.parent = null; // Detach partent
    }

    void Update() {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, 0.4f);
    }
}
