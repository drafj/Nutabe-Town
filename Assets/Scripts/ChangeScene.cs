using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject portal;
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Portal")
        {
            SceneManager.LoadScene("Level1");
        }

        if (other.tag == "Ropa")
        {
            portal.SetActive(true);
        }
    }
}
