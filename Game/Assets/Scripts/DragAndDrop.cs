using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool hasBeenDragged = false;
    private Rigidbody2D rb2D;
    private Vector2 originalPosition;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.bodyType = RigidbodyType2D.Kinematic; // Lock the object's position initially
        originalPosition = rb2D.position;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb2D.position = new Vector2(mousePosition.x, originalPosition.y);
        }
    }

    public void OnMouseDown()
    {
        if (Merge.spawnedYet == "y")
        {
            Merge.spawnedYet = "n";
        }

        if (!hasBeenDragged)
        {
            isDragging = true;
            rb2D.bodyType = RigidbodyType2D.Dynamic; // Enable gravity when dragging starts
        }
    }

    public void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;
            hasBeenDragged = true;
            rb2D.bodyType = RigidbodyType2D.Dynamic; // Enable gravity when released
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==gameObject.tag)
        {
            Merge.spawnPos = transform.position;
            Merge.newKue = "y";
            Merge.whichKue = int.Parse(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
