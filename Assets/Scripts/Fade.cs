using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        //Invoke("FadeOut", 3);
    }

    // Update is called once per frame
    public void FadeOut()
    {
        animator.Play("FadeOut");
    }
}
