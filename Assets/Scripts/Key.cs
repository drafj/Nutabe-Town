using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject panel;
    public GameObject key;
    public GameObject door;
    public bool getKey;
    public Collider coll;
    void Start()
    {
        coll.GetComponent<Collider>();
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
            coll.isTrigger = true;
            panel.SetActive(true);
        }

        if (other.tag == "Door" && getKey == true) 
        {
            Destroy(door);
        }
    }
}
