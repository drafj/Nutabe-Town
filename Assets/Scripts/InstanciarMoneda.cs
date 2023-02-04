using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarMoneda : MonoBehaviour
{
    public GameObject esferaPrueba;
    public Transform creador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            CrearMoneda();
        }
    }

    void CrearMoneda()
    {
        GameObject esferaCreada = Instantiate(esferaPrueba, creador);
        esferaCreada.transform.parent = null;
    }
}
