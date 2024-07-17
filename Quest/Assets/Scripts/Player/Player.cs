using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(QuestManager))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private QuestManager questManager;

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
        if (!TryGetComponent<QuestManager>(out questManager))
        {
            Debug.LogError($"Could not find QuestManager");
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

            if (results[0].transform.tag == "Npc" || results[0].transform.tag == "Item")
            {
                HandleQuests(results[0]);
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

    private void HandleQuests(RaycastHit2D result)
    {
        switch (result.transform.tag)
        {
            case "Npc":
                if (result.transform.TryGetComponent(out Npc npc))
                {
                    if (!npc.hasQuest) { return; }
                    if (!npc.quest)
                    {
                        Debug.LogError($"Could not find {npc} Quest");
                        return;
                    }

                    questManager.HandleQuest(npc.quest);
                }
                break;
            case "Item":
                if (result.transform.TryGetComponent(out Item item))
                {
                    if (!item.hasQuest) { return; }
                    if (!item.quest)
                    {
                        Debug.LogError($"Could not find {item} Quest");
                        return;
                    }

                    questManager.HandleQuest(item.quest);
                }
                break;
            default:
                break;
        }
    }
}