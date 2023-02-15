using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class ChangeScene : MonoBehaviour
{
    public GameObject panelTunica;
    public GameObject artilugio;
    public GameObject portal;
    public Fade fade;
    public Movement playerController;
    public CinemachineFreeLook freeLook;
    public FMODUnity.StudioEventEmitter emitter;
    public List<Enemy> enemies = new List<Enemy>(); 
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Portal/01 Paso portal pasado");
            fade.FadeOut();
            playerController.anim.SetBool("IsMoving", false);
            playerController.enabled = false;
            playerController.GetComponent<Collider>().enabled = false;
            DesableEnemies();
            freeLook.enabled = false;
            Invoke("WaitFade", 3f);
            
        }
    
        if (other.tag == "Portal2")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Portal/02 Paso portal presente");
            fade.FadeOut();
            playerController.anim.SetBool("IsMoving", false);
            playerController.enabled = false;
            DesableEnemies();
            freeLook.enabled = false;
            Invoke("WaitFade2", 3f);
            
        }
        if (other.tag == "Ropa")
        {
            Destroy(artilugio);
            portal.SetActive(true);
            emitter.Play();
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelTunica.SetActive(true);
            Time.timeScale = 0;
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

    void DesableEnemies()
    {
        foreach (var item in GameObject.FindObjectsOfType<Enemy>())
        {
            enemies.Add(item);
        }
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].agent.isStopped = true;
            enemies[i].agent.enabled = false;
            enemies[i].anim.SetBool("IsMoving", false);
            enemies[i].enabled = false;
        }
    }

}
