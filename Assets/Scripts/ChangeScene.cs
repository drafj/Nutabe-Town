using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject artilugio;
    public GameObject portal;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            SceneManager.LoadScene("Level2");
        }
        if (other.tag == "Portal2")
        {
            SceneManager.LoadScene(0);
        }
        if (other.tag == "Ropa")
        {
            Destroy(artilugio);
            portal.SetActive(true);
        }
    }
}
