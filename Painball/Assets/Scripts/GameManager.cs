using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField ]private GameObject _boardParent;
    [SerializeField ]private AudioMusicManager _music;
    
    // Start is called before the first frame update
    void Start()
    {
        HideObject(_boardParent);
        _music.StopMusic();
    }

    public void ShowObject(GameObject target){
        target.SetActive(true);
        _music.PlayMusic();
    }

    public void HideObject(GameObject target){
        target.SetActive(false);
    }


}
