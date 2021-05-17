using System.Collections;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public bool occupied = false;

    private void OnTriggerEnter(Collider col) {
        if (col.tag == "NPC") {
            occupied = true;
        }   
    }

    private void OnTriggerExit(Collider col) {
        if (col.tag == "NPC") {
            occupied = false;
        }
    }
}
