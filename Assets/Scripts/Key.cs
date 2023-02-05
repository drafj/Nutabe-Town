using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject key;
    public GameObject door;
    public bool getKey;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            Destroy(key);
            getKey = true;
        }

        if (other.tag == "Door" && getKey == true) 
        {
            Destroy(door);
        }
    }
}
