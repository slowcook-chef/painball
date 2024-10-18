using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MortalityDisplay : MonoBehaviour
{
    [SerializeField]private string deathSceneName="DeathScene";
    public SpriteRenderer[] ballIcons;

    public void ShowLife(int life){
        for (int i = 0; i < ballIcons.Length; i++)
        {
            //enables and disables
            ballIcons[i].enabled = i < life;
        }
    } 

    public void LoadDeath(){
        SceneManager.LoadScene(deathSceneName);
    }
}
