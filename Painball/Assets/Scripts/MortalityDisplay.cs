using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MortalityDisplay : MonoBehaviour
{
    public Scene deathScene;
    public SpriteRenderer[] ballIcons;

    public void ShowLife(int life){
        for (int i = 0; i < ballIcons.Length; i++)
        {
            //enables and disables
            ballIcons[i].enabled = i < life;
        }
    } 

    public void LoadDeath(){
        SceneManager.LoadScene(deathScene.name);
    }
}
