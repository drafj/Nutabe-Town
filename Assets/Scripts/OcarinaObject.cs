using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OcarinaObject : MonoBehaviour
{
    public int ocarinaCont = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ocarina")
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Prop/OcarinaPartes");
            Destroy(other.gameObject);
            ocarinaCont++;
            if (ocarinaCont >= 3)
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/Prop/Ocarina");
                GetComponent<PlayerController>().ocarina = true;
            }
        }
    }
}
