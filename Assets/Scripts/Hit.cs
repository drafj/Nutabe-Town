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
            Invoke("WaitFade", 3f);
            fade.Lose();
            playerController.GetComponent<Movement>().enabled = false;
            freeLook.enabled = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/vigilante/hit");
        }
    }

    void WaitFade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
