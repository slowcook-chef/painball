using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boardParent;
    int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        HideBoard();
        
    }

    public void ShowBoard(){
        boardParent.SetActive(true);
    }

    public void HideBoard(){
        boardParent.SetActive(false);
    }

    public void LoseLife(){
        lives -= 1;
        if(lives<=0){
            //you lost
        }
        //else spawn new ball
        
    }


}
