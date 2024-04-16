using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTriggers : MonoBehaviour {

    [SerializeField] private Transform cameraTarget;
    [SerializeField] private GameObject cameraObj;
    [SerializeField] private float targetX = 0;
    [SerializeField] private float targetY = 0;
    [SerializeField] private float targetSize = 0;

    private VillageCamera cameraScript;

    void Start () {
        cameraScript = cameraObj.GetComponent<VillageCamera>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        cameraTarget.position = new Vector3(targetX, targetY, -10.0f);
        cameraScript.targetSize = targetSize;
    }
}
