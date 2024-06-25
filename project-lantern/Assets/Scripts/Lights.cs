using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{
    [SerializeField] private GameObject[] lights;
    // Start is called before the first frame update
    void Start()
    {
        lights[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("level 1") >= 1)
        {
            lights[1].SetActive(true);
        }
    }
}
