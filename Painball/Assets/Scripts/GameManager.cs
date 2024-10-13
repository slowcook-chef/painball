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
        
        
    }

    public void ShowBoard(){
        boardParent.SetActive(true);
    }

    public void HideBoard(){
        boardParent.SetActive(false);
    }

    public void LoseLife(){
        lives -= 1;
    }


}
