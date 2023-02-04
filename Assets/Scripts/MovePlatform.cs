using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform[] target;

    public float speed;

    public int curPosition;
    public int nextPosition;
    void Start()
    {
        
    }

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
    }
}
