using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Make sure to check the "Is Trigger" box
[RequireComponent(typeof(BoxCollider2D))]
public class BallReset : MonoBehaviour
{

    public Transform resetPosition; // Set this to where you want the ball to respawn
    [SerializeField]private Mortality _mortality;
    //audio events
    FMOD.Studio.EventInstance audio_ball_sink;
    FMOD.Studio.EventInstance audio_ambience_oneshot_scary;

    private void Start()
    {
        //audio assign audio events
        audio_ball_sink = FMODUnity.RuntimeManager.CreateInstance("event:/ball_sink");
        audio_ambience_oneshot_scary = FMODUnity.RuntimeManager.CreateInstance("event:/ambience_oneshots_scary");
        //attach audio location to object location
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(audio_ball_sink, transform, GetComponent<Rigidbody2D>());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball")) // Make sure the ball has the "Ball" tag
        {
            other.transform.position = resetPosition.position; // Move the ball to the spawn position
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Reset the velocity
            _mortality.LoseLife();
            //audio events
            audio_ambience_oneshot_scary.start();
            audio_ball_sink.start();
        }
    }

    private void OnDestroy()
    {
        audio_ambience_oneshot_scary.release();
        audio_ball_sink.release();
    }


}

