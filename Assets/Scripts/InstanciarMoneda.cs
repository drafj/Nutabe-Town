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
        GameManager.instance.coins.Add(esferaCreada);
    }
}
