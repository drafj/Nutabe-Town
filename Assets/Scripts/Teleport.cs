using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform objetivo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = objetivo.transform.position;
        }

        if (other.tag == "Enemy")
        {
            other.transform.position = objetivo.transform.position;
        }
    }
}
