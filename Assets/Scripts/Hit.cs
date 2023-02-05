using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Cinemachine;

public class Hit : MonoBehaviour
{
    public Fade fade;
    public CinemachineFreeLook freeLook;
    public FMODUnity.StudioEventEmitter emitter;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            Invoke("WaitFade", 3f);
            fade.Lose();
            playerController.GetComponent<Movement>().enabled = false;
            freeLook.enabled = false;
            emitter.Play();
        }
    }

    void WaitFade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
