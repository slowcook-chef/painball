using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaunchZone : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    public Transform launchPointer;
    public float maxForce;

    //FMOD event variables
    private FMOD.Studio.EventInstance audio_plunger_draw_begin;
    private FMOD.Studio.EventInstance audio_plunger_draw_release;
    private FMOD.Studio.EventInstance audio_plunger_draw_lp;

    [Range(0.1f, 5f)]
    public float maxTimeToCharge = 3f;


    [Range(0.0f, 1f)]
    private float timeElapsed = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        //setting FMOD event variable values
        audio_plunger_draw_begin = FMODUnity.RuntimeManager.CreateInstance("event:/plunger_draw_begin");
        audio_plunger_draw_release = FMODUnity.RuntimeManager.CreateInstance("event:/plunger_draw_release");
        audio_plunger_draw_lp = FMODUnity.RuntimeManager.CreateInstance("event:/plunger_draw_lp");

    }

    private Rigidbody2D CheckForBallInZone()
    {
        // Get the center and size of the BoxCollider
        Vector2 boxCenter = boxCollider.transform.TransformPoint(boxCollider.offset);
        Vector2 boxSize = boxCollider.size;

        // Detect all colliders inside the BoxCollider
        Collider2D[] colliders = Physics2D.OverlapAreaAll(boxCenter, boxCenter + boxCollider.size);

        foreach(Collider2D collider in colliders)
            // Process the detected colliders
            if(collider.gameObject.tag == "Ball"){
                return collider.gameObject.GetComponent<Rigidbody2D>();
            }
        return null;
    }

    public void Launch(float charge){
        Rigidbody2D ball = CheckForBallInZone();
        if(ball==null){
            print("No Balls");
            //No ball detected in launch zone
            return;
        }
        //calculate desired launch direction
        Vector2 direction = launchPointer.position - this.transform.position;
        direction = direction.normalized;

        //Calculate direction * force * charge
        direction *= maxForce;
        direction *= charge;

        //Exert force on ball
        ball.AddForce(direction, ForceMode2D.Impulse);
    }
    
    //Detect input
    private void Update(){
        if(Input.GetKey(KeyCode.Space)){
            timeElapsed += Time.deltaTime;
            //print("Charge: %"+TimeToCharge());

            //audio
            //audio_plunger_draw_lp.setParameterByName("plunger_draw", TimeToCharge());
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("plunger_draw", TimeToCharge());
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            Launch(TimeToCharge());
            timeElapsed = 0;

            //audio
            audio_plunger_draw_release.start(); //play plunger release audio
            audio_plunger_draw_lp.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT); //stop the plunger draw loop when letting go of spacebar
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //audio
            audio_plunger_draw_begin.start(); //play the plunger draw begin audio
            audio_plunger_draw_lp.start(); //begin the plunger draw loop
        }
    }

    private float TimeToCharge(){
        float result = Mathf.Lerp(0,1, timeElapsed/maxTimeToCharge);
        return result;
    }

    private void OnDestroy()
    {
        //release loaded audio from memory
        audio_plunger_draw_lp.release();
        audio_plunger_draw_release.release();
        audio_plunger_draw_begin.release();
    }

}
