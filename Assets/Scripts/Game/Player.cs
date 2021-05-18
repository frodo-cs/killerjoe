using UnityEngine;

public class Player : MonoBehaviour {

    public static bool SolvingPuzzle = false;
    [SerializeField] Waypoint waypoint;

    private void Update() {
        if (Input.GetButtonDown("Jump") && waypoint.occupied) {
            GameEvents.current.PuzzleSolvedTrigger();
        }
    }

}