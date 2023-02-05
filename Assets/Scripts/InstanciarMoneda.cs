using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InstanciarMoneda : MonoBehaviour
{
    public GameObject esferaPrueba;
    public Transform creador;
    public int amountOfCoins;
    public bool canTakeCoins;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && amountOfCoins > 0 && canTakeCoins)
        {
            CrearMoneda();
            amountOfCoins--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Coineable"))
        {
            canTakeCoins = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Coineable"))
        {
            canTakeCoins = false;
        }
    }

    void CrearMoneda()
    {
        GameObject esferaCreada = Instantiate(esferaPrueba, creador);
        esferaCreada.transform.parent = null;
        GameManager.instance.coins.Add(esferaCreada);
    }
}
