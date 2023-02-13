using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyString : MonoBehaviour
{
    public GameObject panelAxe;
    public bool gotAxe = false;
    public GameObject axe;
    public GameObject cuerda;
    public GameObject key;
    public Rigidbody rbTrap;

    void Start()
    {
        rbTrap.GetComponent<Rigidbody>();
        rbTrap.isKinematic = true;
        key.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe")
        {
            Destroy(axe);
            gotAxe = true;
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelAxe.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cuerda")
        {
            if (gotAxe == true && Input.GetKeyDown("q"))
            {
                Destroy(cuerda);
                key.SetActive(true);
                rbTrap.isKinematic = false;
                FMODUnity.RuntimeManager.PlayOneShot("event:/Prop/21 Prop corta cuerda hacha");
            }
        }
    }
}
