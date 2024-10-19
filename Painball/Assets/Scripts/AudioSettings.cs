using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.Bus PinballMachine;
    float PinballMachineVolume = 1f;

    void Awake()
    {
        // Initialize the PinballMachine bus
        PinballMachine = FMODUnity.RuntimeManager.GetBus("bus:/pinball_machine");
    }

    void Update()
    {
        // Set the volume only for the PinballMachine bus
        PinballMachine.setVolume(PinballMachineVolume);
    }

    public void PinballMachineVolumeLevel(float newPinballMachineVolume)
    {
        PinballMachineVolume = newPinballMachineVolume;
    }
}
