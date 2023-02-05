using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool playerCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) && !playerCoin)
        {
            GameManager.instance.coins.Remove(gameObject);
            gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out InstanciarMoneda InstanciarMoneda) && playerCoin)
        {
            InstanciarMoneda.amountOfCoins = 10;
            gameObject.SetActive(false);
        }
    }
}
