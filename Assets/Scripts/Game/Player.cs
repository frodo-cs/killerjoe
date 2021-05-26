using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    public static bool SolvingPuzzle = false;
    [SerializeField] Waypoint waypoint;

    private void Start() {
        GameEvents.current.OnPuzzleSolved += PuzzleSolved;
    }

    private void PuzzleSolved() {
        SolvingPuzzle = false;
    }

    private void Update() {
        if (Input.GetButtonDown("Jump") && waypoint.occupied) {
            GameEvents.current.PuzzleSolvedTrigger();
            SolvingPuzzle = true;
        }
    }
}