using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField ]private GameObject _boardParent;
    [SerializeField ]private GameObject _evilBoard;
    [SerializeField ]private GameObject _mainMenu;
    [SerializeField ]private AudioMusicManager _music;
    [SerializeField] private DialogueSystemController dialogueSystem;

    private void Update(){
        if(Input.GetKeyDown(KeyCode.H)){
            StartDemonicBoard();
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
        dialogueSystem.StartConversation("Spinny Hello");
        HideObject(_mainMenu);
    }
    public void StartRegularBoard(){
        HideObject(_evilBoard);
        ShowObject(_boardParent);
        _music.PlayMusic(0);
    }

    public void StartDemonicBoard(){
        HideObject(_boardParent);
        ShowObject(_evilBoard);
        _music.PlayMusic(1);
    }

    public void Win(){
        Debug.Log("You Win!");
        _music.StopMusic();
        ShowObject(_mainMenu);
    }

    public void Lose(){

    }

}
