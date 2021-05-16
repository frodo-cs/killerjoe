using System;
using UnityEngine;

public class NPC : MonoBehaviour {


    private GameObject[] waypoint;
    private Transform targetWaypoint;
    private Animator animator;
    private float minDistance = 0.5f;
    private float speed = 2.0f;
    private int waypointIndex = 0;
    private bool paying = false;
    private bool enemy = false;

    private void Awake() {
        waypoint = new GameObject[3];
        // waypoint[waypointIndex] = GameObject.FindGameObjectWithTag("Waiting");
        waypoint[waypointIndex] = GameObject.FindGameObjectWithTag("Payment");
        waypoint[waypointIndex + 1] = GameObject.FindGameObjectWithTag("Exit");
        animator = GetComponent<Animator>();
    }

    private void Start() {
        targetWaypoint = waypoint[waypointIndex].GetComponent<Transform>();
    }

    private void Update() {
        float movementStep = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        if(!OnTarget(distance) && !targetWaypoint.GetComponent<Waypoint>().occupied) {
            Move(movementStep);
        } else if (!OnTarget(distance) && targetWaypoint.GetComponent<Waypoint>().occupied) {
            Wait();
        } else {
            if(waypointIndex == 0) {
                Pay();
                targetWaypoint = waypoint[++waypointIndex].GetComponent<Transform>();
                GameEvents.current.NPCDestroyedTrigger();
            } else {            
                Destroy(gameObject);
            }
        }

    }

    private void Move(float m) {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, m);
        animator.SetBool("Moving", true);
        animator.SetBool("Waiting", false);
        animator.SetBool("Paying", false);
    }

    private void Pay() {
        animator.SetBool("Moving", false);
        animator.SetBool("Waiting", false);
        animator.SetBool("Paying", true);
    }

    private void Wait() {
        animator.SetBool("Moving", false);
        animator.SetBool("Waiting", true);
        animator.SetBool("Paying", false);
    }

    bool OnTarget(float dist) {
        return dist < minDistance;
    }
}
