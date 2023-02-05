using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Exit();
    }
}
