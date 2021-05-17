using System.Collections;
using UnityEngine;


public class Player : MonoBehaviour {

    [SerializeField] Waypoint waypoint;

    private void Update() {
        if (Input.GetButtonDown("Jump") && waypoint.occupied) {
            GameEvents.current.PuzzleSolvedTrigger();
        }
    }

}
