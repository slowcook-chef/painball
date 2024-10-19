using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField ]private GameObject _boardParent;
    [SerializeField ]private GameObject _mainMenu;
    [SerializeField ]private AudioMusicManager _music;
    [SerializeField] private DialogueSystemController dialogueSystem;

    
    // Start is called before the first frame update
    void Start()
    {
        HideObject(_boardParent);
        _music.StopMusic();
    }

    public void ShowObject(GameObject target){
        target.SetActive(true);
        //_music.PlayMusic();
    }

    public void HideObject(GameObject target){
        target.SetActive(false);
    }

    public void StartDialogue(){
        dialogueSystem.StartConversation("Spinny Hello");
        HideObject(_mainMenu);
    }
    void StartRegularBoard(){
        
    }

    void StartDemonicBoard(){

    }

}
