using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LaunchZone : MonoBehaviour
{
    private BoxCollider boxCollider;
    public Transform launchPointer;
    public float maxForce;


    [Range(1f, 5f)]
    public float maxTimeToCharge = 3f;


    [Range(0.0f, 1f)]
    private float timeElapsed = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private Rigidbody CheckForBallInZone()
    {
        // Get the center and size of the BoxCollider
        Vector3 boxCenter = boxCollider.transform.position + boxCollider.center;
        Vector3 boxSize = boxCollider.size / 2;

        // Detect all colliders inside the BoxCollider
        Collider[] colliders = Physics.OverlapBox(boxCenter, boxSize, boxCollider.transform.rotation);

        // Process the detected colliders
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject.tag == "Ball"){
                return collider.gameObject.GetComponent<Rigidbody>();
            }
        }
        return null;
    }

    public void Launch(float charge){
        Rigidbody ball = CheckForBallInZone();
        if(ball==null){
            print("No Balls");
            //No ball detected in launch zone
            return;
        }
        //calculate desired launch direction
        Vector3 direction = launchPointer.position - this.transform.position;
        direction = direction.normalized;

        //Calculate force
        direction *= maxForce;
        direction *= charge;

        //Exert force on ball
        ball.AddForce(direction, ForceMode.Impulse);
    }
    
    //Detect input
    private void Update(){
        if(Input.GetKey(KeyCode.Space)){
            timeElapsed += Time.deltaTime;
            print("Charge: %"+TimeToCharge());
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            Launch(TimeToCharge());
            timeElapsed = 0;
        }
    }

    private float TimeToCharge(){
        float result = Mathf.Lerp(0,1, timeElapsed/maxTimeToCharge);
        return result;
    }

}
