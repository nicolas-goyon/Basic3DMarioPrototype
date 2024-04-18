using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumbRaycastDistance = 0.1f;

    private Rigidbody rb;
    private BoxCollider boxCollider;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }


    private void Start() {
        GameInput.Instance.OnJump += OnJump;
    }

    private void OnJump(object sender, System.EventArgs e) {
        if (CanJump()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void Update() {
        Vector2 movements = GameInput.Instance.GetPlayerMovements();
        Vector3 move = new(movements.x, 0, movements.y);
        transform.Translate(speed * Time.deltaTime * move);
        
    }


    private bool CanJump() {
        float boxColliderHeight = GetBoxColliderHeight();
        float boxColliderRadius = GetBoxColliderRadius();
        //Vector3 bottomPoint = transform.position + Vector3.down * (boxColliderHeight / 2 - boxColliderRadius);
        //Vector3 headPoint = transform.position + Vector3.up * (boxColliderHeight / 2 - boxColliderRadius);
        Vector3 bottomPoint = transform.position;
        Vector3 headPoint = transform.position + Vector3.up * boxColliderHeight;
        Vector3 checkDirection = Vector3.down;
        float maxDistance = jumbRaycastDistance;
        return Physics.CapsuleCast(bottomPoint, headPoint, boxColliderRadius, checkDirection, maxDistance);
    }

    private float GetBoxColliderHeight() {
        return boxCollider.size.y;
    }

    private float GetBoxColliderRadius() {
        return boxCollider.size.x / 2;
    }



}
