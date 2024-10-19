using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    Vector2 direction;
    public Transform aimTransform;
    public float launchForce = 25f;

    //audio events
    FMOD.Studio.EventInstance audio_slingshot_hit;

    // Start is called before the first frame update
    void Start()
    {
        direction = (aimTransform.position - transform.position).normalized;

        //audio assign audio events
        audio_slingshot_hit = FMODUnity.RuntimeManager.CreateInstance("event:/slingshot_hit");
        //attach audio location to object location
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(audio_slingshot_hit, gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a Rigidbody2D
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(direction * launchForce, ForceMode2D.Impulse);

            //audio play slingshot hit audio
            audio_slingshot_hit.start();
        }
    }

    private void OnDestroy()
    {
        //audio release from memory on object destroy
        audio_slingshot_hit.release();
    }

}
