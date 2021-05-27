using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {
  
    [SerializeField] Waypoint waypoint;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && waypoint.occupied) {
            GameEvents.current.PuzzleSolvedTrigger();
        }
    }
}