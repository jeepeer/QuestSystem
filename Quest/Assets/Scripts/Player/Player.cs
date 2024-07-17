using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        if (TryGetComponent<Rigidbody2D>(out rigidbody))
        {
            rigidbody.gravityScale = 0.0f;
        }
        else
        {
            Debug.LogError($"Could not find RigidBody2D");
        }
    }

    private void FixedUpdate()
    {
        HandleInput();
    }
    
    private void HandleInput()
    {
        Movement();
        Interact();
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 velocity = rigidbody.position + new Vector2(x, y) * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(velocity);
    }
    
    private void Interact()
    {
        if (Input.GetKey(KeyCode.Space))
        {

        }
    }
}