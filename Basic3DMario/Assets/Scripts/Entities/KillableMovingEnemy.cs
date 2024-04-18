using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillableMovingEnemy : Enemy
{
    [SerializeField] private int scoreValue = 1;
    [SerializeField] private WeakPoint weakPoint;


    [SerializeField] private List<Waypoint> waypoints;
    [SerializeField] private float speed = 1f;

    private int currentWaypointIndex = -1;


    private bool hasBeenTriggered = false;

    private void Start() {
        weakPoint.OnWeakPointTouched += WeakPoint_OnWeakPointTouched;
        if (waypoints.Count > 0) {
            currentWaypointIndex = 0;
            transform.position = waypoints[currentWaypointIndex].transform.position;
        }
    }

    private void Update() {
        if (IsNoWaypoints()) {
            return;
        }

        Vector3 targetPosition = waypoints[currentWaypointIndex].transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) {
            currentWaypointIndex = GetNextWaypointIndex();
        }
    }


    private int GetNextWaypointIndex() {
        return (currentWaypointIndex + 1) % waypoints.Count;
    }

    private bool IsNoWaypoints() {
        return currentWaypointIndex == -1;
    }
    private void WeakPoint_OnWeakPointTouched(object sender, Collision e) {
        if (hasBeenTriggered) return;


        if (e.gameObject == Player.Instance.gameObject) {
            hasBeenTriggered = true;
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }

    private new void OnCollisionEnter(Collision collision) {
        if ( hasBeenTriggered ) return;

        if (collision.gameObject == Player.Instance.gameObject) {
            hasBeenTriggered = true;
            GameManager.Instance.GameOver("You were killed by " + enemyName);
        }
    }


}
