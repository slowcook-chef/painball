using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField ]private GameObject _boardParent;
    [SerializeField ]private GameObject _evilBoard;
    [SerializeField ]private GameObject _mainMenu;
    [SerializeField ]private AudioMusicManager _music;
    [SerializeField] private DialogueSystemController dialogueSystem;
    [SerializeField] private GameObject spinny;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            EasyLevelBeaten();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        HideObject(_boardParent);
        HideObject(_evilBoard);
        _music.StopMusic();
    }

    private void ShowObject(GameObject target){
        target.SetActive(true);
        
    }

    private void HideObject(GameObject target){
        target.SetActive(false);
    }

    public void StartDialogue(){
        _music.PlayMusic(0);
        dialogueSystem.StartConversation("Spinny Hello");
        HideObject(_mainMenu);
    }
    public void StartRegularBoard(){
        HideObject(_evilBoard);
        ShowObject(_boardParent);
        //_music.PlayMusic(0);
    }

    public void EasyLevelBeaten(){
        HideObject(_boardParent);
        _music.StopMusic();
        spinny.SetActive(true);
        dialogueSystem.StartConversation("Easy Level Beaten");
    }
    public void StartDemonicBoard(){
        HideObject(_boardParent);
        ShowObject(_evilBoard);
        _music.PlayMusic(1);
    }

    public void Win(){
        Debug.Log("You Win!");
        _music.StopMusic();
        SceneManager.LoadScene("Win Scene");
    }

    public void Lose(){

    }

    public void Quit(){
        Application.Quit();
    }

}
