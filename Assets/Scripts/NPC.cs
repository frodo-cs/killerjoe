using System;
using UnityEngine;

enum State { Waiting, Moving, Payment }

public class NPC : MonoBehaviour {


    private GameObject[] waypoint;
    private Transform targetWaypoint;
    private Animator animator;
    private float minDistance = 0.05f;
    private float speed = 2.0f;
    private State state = State.Moving;
    private int waypointIndex = 0;

    bool enemy = false;

    private void Awake() {
        waypoint = new GameObject[3];
        waypoint[waypointIndex] = GameObject.FindGameObjectWithTag("Waiting");
        waypoint[waypointIndex + 1] = GameObject.FindGameObjectWithTag("Payment");
        waypoint[waypointIndex + 2] = GameObject.FindGameObjectWithTag("Exit");
        animator = GetComponent<Animator>();
    }

    private void Start() {
        targetWaypoint = waypoint[waypointIndex].GetComponent<Transform>();
    }

    private void Update() {
        float movementStep = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        
        SetState(distance);

        switch (state) {
            case State.Moving:
                Move(movementStep);
                ChangeTarget(distance);
                break;
            case State.Payment:
                Pay();
                break;
            default:
                ChangeTarget(distance);
                Wait();
                break;
        }
    }

    private void SetState(float dist) {
        if (state!= State.Waiting && targetWaypoint.GetComponent<Waypoint>().occupied && !OnTarget(dist)) {
            state = State.Waiting;
        } else if (targetWaypoint == waypoint[1].GetComponent<Transform>() && OnTarget(dist)) {
            state = State.Payment;
        } else {
            state = State.Moving;
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

    void ChangeTarget(float dist) {
        if (OnTarget(dist)) {
            waypointIndex++;
            if (waypointIndex < waypoint.Length) {
                targetWaypoint = waypoint[waypointIndex].GetComponent<Transform>();
            } else {
                GameEvents.current.NPCDestroyedTrigger();
                Destroy(gameObject);
            }
        }
    }

    bool OnTarget(float dist) {
        return dist < minDistance;
    }
}
