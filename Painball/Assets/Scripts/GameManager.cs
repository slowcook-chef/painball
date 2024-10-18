using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField ]private GameObject _boardParent;
    int lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        HideBoard();
        
    }

    public void ShowBoard(){
        _boardParent.SetActive(true);
    }

    public void HideBoard(){
        _boardParent.SetActive(false);
    }

    public void LoseLife(){
        lives -= 1;
        if(lives<=0){
            //you lost
        }
        //else spawn new ball
        
    }


}
