using System;
using UnityEngine;

public class NPC : MonoBehaviour {

    private GameObject payingArea;
    private GameObject exit;
    private Transform targetWaypoint;
    private Animator animator;
    private float minDistance = 0.1f;
    private float speed = 2.0f;
    [HideInInspector] public bool enemy = false;
    private bool payingTriggered = false;

    private void Awake() {
        payingArea = GameObject.FindGameObjectWithTag("Payment");
        exit = GameObject.FindGameObjectWithTag("Exit");
        animator = GetComponent<Animator>();
    }

    private void Start() {
        targetWaypoint = payingArea.GetComponent<Transform>();
        GameEvents.current.OnPuzzleSolved += GoToExit;
    }

    private void Update() {
        float movementStep = speed * Time.deltaTime;
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        if (!OnTarget(distance)) {
            if (transform.rotation.y < 0.707)
                transform.Rotate(Vector3.up * movementStep * 100);
            Move(movementStep);
        } else if (targetWaypoint.GetComponent<Waypoint>().occupied && !OnTarget(distance)) {
            Wait();
        } else if (OnTarget(distance)) {
            if (targetWaypoint == payingArea.GetComponent<Transform>()) {
                if (transform.rotation.y >= 0.2)
                    transform.Rotate(Vector3.down * movementStep * 70);
                else if (!payingTriggered) {
                    GameEvents.current.PayingPositionTrigger();
                    payingTriggered = true;
                }  
                Pay();
            } else {
                GameEvents.current.NPCDestroyedTrigger();
                Destroy(gameObject);
            }
        }
    }

    private void GoToExit() {
        targetWaypoint = exit.GetComponent<Transform>();
       // GameEvents.current.NPCDestroyedTrigger();
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