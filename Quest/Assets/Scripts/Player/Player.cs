using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;

    private void Start()
    {
        if (TryGetComponent<Rigidbody2D>(out rigidbody))
        {
            rigidbody.gravityScale = 0.0f;
        }
        else { Debug.LogError($"Could not find RigidBody2D"); }
        if (!TryGetComponent<BoxCollider2D>(out collider))
        {
            Debug.LogError($"Could not find Collider2D");
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D[] results = ColliderCastResults();
            if (results.Length <= 0) { return; }

            if (results[0].transform.tag == "Npc")
            {
                results[0].transform.GetComponent<Npc>()?.OnInteracted();
            }
            else if(results[0].transform.tag == "Item")
            {
                results[0].transform.GetComponent<Item>()?.OnInteracted();
            }
        }
    }
    
    private RaycastHit2D[] ColliderCastResults()
    {
        RaycastHit2D[] results = new RaycastHit2D[1];
        collider.size *= 2.0f;
        if (collider.Cast(collider.bounds.center, results, 0.0f, true) > 0)
        {
            collider.size /= 2.0f;
            return results;
        }

        collider.size /= 2.0f;
        return new RaycastHit2D[0];
    }
}