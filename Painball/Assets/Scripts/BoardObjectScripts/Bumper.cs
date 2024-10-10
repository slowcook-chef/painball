using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float launchForce = 500f; // Force applied when hitting the bumper

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Calculate the direction to launch the player away from the bumper
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            rb.AddForce(direction * launchForce);
        }
    }
}
