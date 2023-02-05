using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFmod : MonoBehaviour
{

    
    public FMODUnity.StudioEventEmitter[] emitter;

    public void playSound(int i)
    {
        emitter[i].Play();
    }

    public void stopSound(int i)
    {
        emitter[i].Stop();
    }
}

