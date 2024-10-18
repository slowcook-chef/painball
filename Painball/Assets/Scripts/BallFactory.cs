using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFactory : MonoBehaviour
{
    [SerializeField]private BallReset respawn;
    private Stack<GameObject> ballStack = new Stack<GameObject>();
    public void StoreBall(GameObject ball){
        ballStack.Push(ball);
        ball.SetActive(false);
    }

    public void LoadBall(){
        GameObject ball = ballStack.Pop();
        respawn.ResetBall(ball);
        ball.SetActive(enabled);
    }


}
