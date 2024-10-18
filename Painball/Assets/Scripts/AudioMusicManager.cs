using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMusicManager : MonoBehaviour
{
    public int hell_state;

    //instantiate fmod event instances
    private FMOD.Studio.EventInstance audio_painball_music;

    private void Start()
    {
        //assign fmod events
        audio_painball_music = FMODUnity.RuntimeManager.CreateInstance("event:/painball_music");

        //start the music
        //PlayMusic();
    }
    void Update()
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("hell_state", hell_state);
    }

    private void OnDestroy()
    {
        StopMusic();
        audio_painball_music.release();
    }

    public void StopMusic(){
        audio_painball_music.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
    public void PlayMusic(){
        audio_painball_music.start();

    }
}
