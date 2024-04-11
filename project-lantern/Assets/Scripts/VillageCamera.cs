using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class VillageCamera : MonoBehaviour
{
    [SerializeField] private Transform movePoint;
    [SerializeField] private float speed = 3;
    
    public float targetSize = 8;

    void Start() {
        movePoint.parent = null; // Detach partent
    }

    void Update() {
        float movementAmout = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmout);
        float blend = 1f - Mathf.Pow(1f - 0.1f, Time.deltaTime * 30);
        Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, blend);
    }
}
