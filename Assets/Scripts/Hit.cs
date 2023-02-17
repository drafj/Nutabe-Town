using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class Hit : MonoBehaviour
{
    public Fade fade;
    public CinemachineFreeLook freeLook;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {

            

            FMODUnity.StudioEventEmitter emitter = this.GetComponent<FMODUnity.StudioEventEmitter>();
            if (emitter != null)
            {
                emitter.Play();
                FMODUnity.RuntimeManager.CreateInstance("snapshot:/GameOver").start();
                //Debug.Log("HitPlay");
            }
            
            Invoke("WaitFade", 3f);
            fade.Lose();
            playerController.GetComponent<Movement>().enabled = false;
            freeLook.enabled = false;

            
        }
    }

    void WaitFade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FMODUnity.RuntimeManager.CreateInstance("snapshot:/Reinicio escena").start();
    }
}
