using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ChangeScene : MonoBehaviour
{
    public GameObject artilugio;
    public GameObject portal;
    public Fade fade;
    public Movement playerController;
    public CinemachineFreeLook freeLook;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            fade.FadeOut();
            playerController.anim.SetBool("IsMoving", false);
            playerController.enabled = false;
            freeLook.enabled = false;
            Invoke("WaitFade", 3f);
        }
    
        if (other.tag == "Portal2")
        {
            fade.FadeOut();
            playerController.anim.SetBool("IsMoving", false);
            playerController.enabled = false;
            freeLook.enabled = false;
            Invoke("WaitFade2", 3f);
        }
        if (other.tag == "Ropa")
        {
            Destroy(artilugio);
            portal.SetActive(true);
        }
    }

    void WaitFade()
    {
        SceneManager.LoadScene("Level02");
    }

    void WaitFade2()
    {
        SceneManager.LoadScene(3);
    }
}
