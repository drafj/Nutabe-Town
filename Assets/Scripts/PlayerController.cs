using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class PlayerController : Human
{
    public GameObject maletin;
    public bool gotMaletin = false;
    
    
    public bool ocarina = false;
    public bool ocarinaCC = false;
    
    public int
        potions,
        swords,
        remainingEnemies;
    public GameObject swordPrefab;
    public Transform hand;
    private int isMovementDisabled;
    private CharacterController controller;
    private Movement movement;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<Movement>();
        manager = GameManager.instance;

        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
        {
            remainingEnemies++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "maletin")
        {
            Destroy(maletin);
            gotMaletin = true;
        }
    }

    public void UpdateUIItem(List<TextMeshProUGUI> items, int actualCount)
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].text = actualCount.ToString();
        }
    }

    public void UpdateUIItem(TextMeshProUGUI item, int actualCount)
    {
        item.text = actualCount.ToString();
    }

    public IEnumerator PlayOcarina()
    {
        GameManager.instance.ocarinaPlayed = true;
        yield return new WaitForSeconds(7f);
        GameManager.instance.ocarinaPlayed = false;
    }

    public IEnumerator OcarinaCC()
    {
        ocarinaCC = true;
        yield return new WaitForSeconds(60f);
        ocarinaCC = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !ocarinaCC && ocarina)
        {
            StartCoroutine(PlayOcarina());
            StartCoroutine(OcarinaCC());
        }
    }
}
