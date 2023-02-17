using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFmod : MonoBehaviour
{

    
    public FMODUnity.StudioEventEmitter[] emitter;

    public void playSound(int i)
    {
        emitter[i].Play();
        //Debug.Log("play "+ i);
    }

    public void stopSound(int i)
    {
        emitter[i].Stop();
        //Debug.Log("stop "+ i);
    }

    public void localParameter(string eventoParametroValor)
    {
        string[] values = eventoParametroValor.Split(',');
        int e = int.Parse(values[0]);
        string parametro = (values[1]);
        float valor = float.Parse(values[2]);
        emitter[e].SetParameter(parametro, valor);
        //Debug.Log(e + parametro + " "+ valor);
    }
}

