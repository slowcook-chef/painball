using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    private Stack<GameObject> ballStack = new Stack<GameObject>();
    public void StoreBall(GameObject ball){
        ballStack.Push(ball);
    }

    public void LoadBall(){
        
    }


}
