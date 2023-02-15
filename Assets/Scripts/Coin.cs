using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject panelCoin;
    public bool playerCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Enemy enemy) && !playerCoin)
        {
            enemy.Stop();
            GameManager.instance.coins.Remove(gameObject);
            gameObject.SetActive(false);
        }

        if (other.TryGetComponent(out InstanciarMoneda InstanciarMoneda) && playerCoin)
        {
            InstanciarMoneda.amountOfCoins = 10;
            gameObject.SetActive(false);
            
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            panelCoin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
