using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform[] target;

    public float speed;

    public int curPosition;
    public int nextPosition;

    public bool isOnMovingPlaform;
    public GameObject myPlayer;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target[nextPosition].position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target[nextPosition].position) <= 0)
        {
            curPosition = nextPosition;
            nextPosition++;

            if (nextPosition > target.Length - 1)
            {
                nextPosition = 0;
            }
        }
        /*if (isOnMovingPlaform)
        {
            myPlayer.transform.SetParent(this.transform);
        }
        else
        {
            myPlayer.transform.SetParent(null);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Plataform")
        {
            Debug.Log("aa");
            //isOnMovingPlaform = true;            
        }
        
    }
}
