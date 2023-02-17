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
    private FMOD.Studio.EventInstance instance;

    void Update()
    {
        if (Input.GetKeyDown("e") && amountOfCoins > 0 && canTakeCoins)
        {
            instance = FMODUnity.RuntimeManager.CreateInstance("event:/Prop/16 Prop Suelta Moneda");
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(instance, GetComponent<Transform>(), GetComponent<Rigidbody>());
            instance.start();

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
        GameObject esferaCreada = Instantiate(esferaPrueba, creador.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        GameManager.instance.coins.Add(esferaCreada);
    }
}
