using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 2f;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get input from keyboard
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool sprint = Input.GetKey(KeyCode.LeftShift);

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        // Calculate movement speed
        float currentSpeed = speed;
        if (sprint)
        {
            currentSpeed *= sprintMultiplier;
        }

        // Move the character
        transform.Translate(movement * currentSpeed * Time.deltaTime, Space.World);

        // Update animation parameters
        animator.SetFloat("Speed", movement.magnitude * currentSpeed);
        animator.SetBool("Sprint", sprint);
    }
}
