using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float launchForce = 500f; // Force applied when hitting the bumper

    private FMOD.Studio.EventInstance audio_bumper_hit;

    private void Start()
    {
        //assign audio event instances
        audio_bumper_hit = FMODUnity.RuntimeManager.CreateInstance("event:/bumper_hit");
        //attach audio location to the game object location
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(audio_bumper_hit, transform, GetComponent<Rigidbody2D>());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Calculate the direction to launch the player away from the bumper
            Vector2 direction = (collision.transform.position - transform.position).normalized;
            rb.AddForce(direction * launchForce);

            //audio event calls
            audio_bumper_hit.start();
        }
    }

    private void OnDestroy()
    {
        //audio release from memory on object destroy
        audio_bumper_hit.release();
    }
}
