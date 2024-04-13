using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    
    [SerializeField] private int moveAmount;

    public int GetMoveAmount() {
        return moveAmount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
