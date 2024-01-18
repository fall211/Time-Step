using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    private float movement_speed = 5.0f;
    private float gravity = 9.81f;
    private float jump_strength = 7f;
    private Vector3 applied_force;
    private Vector3 vertical_force;

    private void Update() {
        Movement2D();

        applied_force = Vector3.ClampMagnitude(applied_force, 1) * movement_speed * Time.deltaTime;

        if (controller.isGrounded) {
            vertical_force.y = 0f;
        }

        ApplyGravity();

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded) {
            Jump();
        }

        applied_force += vertical_force * Time.deltaTime;
        // Debug.Log($"{applied_force} {controller.isGrounded}");
        controller.Move(applied_force);
    }

    private void Movement2D() {
        if (Input.GetAxis("Horizontal") != 0) {
            float horizontal_input = Input.GetAxis("Horizontal");
            applied_force += horizontal_input * transform.right;
        }
        if (Input.GetAxis("Vertical") != 0) {
            float vertical_input = Input.GetAxis("Vertical");
            applied_force += vertical_input * transform.forward;

        }
    }
    private void ApplyGravity() {
        vertical_force.y -= gravity * Time.deltaTime * 2f;
    }

    private void Jump() {
        vertical_force.y += jump_strength;
    }
}
