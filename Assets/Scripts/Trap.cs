using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public List<Transform> trapPositions = new List<Transform>();
    public int trapPosIndex = 0;
    public bool falling = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            falling = false;
            GameManager.instance.coins.Clear();
        }
    }
}
