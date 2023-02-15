using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class FMODAdvancedSettings : MonoBehaviour
{
    [SerializeField] private int commandQueueSize = 65536;
    [SerializeField] private int handleInitialSize = 32;
    [SerializeField] private int studioUpdatePeriod = 50;
   

    private void Awake()
    {
        // Obtener la instancia del sistema FMOD Studio
        var studioSystem = RuntimeManager.StudioSystem;

        // Configurar los Advanced Settings
        var advancedSettings = new FMOD.Studio.ADVANCEDSETTINGS();
        advancedSettings.commandqueuesize = commandQueueSize;
        advancedSettings.handleinitialsize = handleInitialSize;
        advancedSettings.studioupdateperiod = studioUpdatePeriod;

        studioSystem.setAdvancedSettings(advancedSettings);
    }
}
