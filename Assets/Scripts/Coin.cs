using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("entra");
            GameManager.instance.coins.Remove(gameObject);
            gameObject.SetActive(false);
        }
    }
}
