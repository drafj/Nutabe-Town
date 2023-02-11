using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject panelCoin; //Agregado por Ed
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
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            InstanciarMoneda.amountOfCoins = 10;
            gameObject.SetActive(false);
            panelCoin.SetActive(true); //Agregado por Ed
            Time.timeScale = 0; //Agregado por Ed
        }
    }
}
