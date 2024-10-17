using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDialogAdvance : MonoBehaviour
{
    FMOD.Studio.EventInstance audio_dialog_advance;

    void Audio_Dialog_Advance()
    {
        audio_dialog_advance = FMODUnity.RuntimeManager.CreateInstance("event:/ui_dialog_advance");
        audio_dialog_advance.start();
    }
}
