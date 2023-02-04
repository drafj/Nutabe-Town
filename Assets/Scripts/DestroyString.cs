using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyString : MonoBehaviour
{
    public bool gotAxe = false;
    public GameObject axe;
    public GameObject cuerda;
    public Rigidbody rbTrap;

    void Start()
    {
        rbTrap.GetComponent<Rigidbody>();
        rbTrap.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Axe")
        {
            Destroy(axe);
            gotAxe = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "cuerda")
        {
            if (gotAxe == true && Input.GetKeyDown("j"))
            {
                Destroy(cuerda);
                rbTrap.isKinematic = false;
            }
        }
    }
}
