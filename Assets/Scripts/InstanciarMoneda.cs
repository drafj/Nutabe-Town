using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarMoneda : MonoBehaviour
{
    public GameObject esferaPrueba;
    public Transform creador;
    public int amountOfCoins;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && amountOfCoins > 0)
        {
            CrearMoneda();
            amountOfCoins--;
        }
    }

    void CrearMoneda()
    {
        GameObject esferaCreada = Instantiate(esferaPrueba, creador);
        esferaCreada.transform.parent = null;
        GameManager.instance.coins.Add(esferaCreada);
    }
}
