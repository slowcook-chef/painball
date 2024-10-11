using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    Vector2 direction;
    public Transform aimTransform;
    public float launchForce = 25f;
    // Start is called before the first frame update
    void Start()
    {
        direction = (aimTransform.position - transform.position).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);
        }
    }

}
