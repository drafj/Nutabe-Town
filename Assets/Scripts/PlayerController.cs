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
    
    
    public int
        potions,
        swords,
        remainingEnemies;
    public GameObject swordPrefab;
    public Transform hand;
    private bool 
        attackColdown,
        powerUp;
    private float 
        enemyDistance,
        temporalDistance;
    private int isMovementDisabled;
    private GameObject enemyCloser;
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

    public IEnumerator EnableMovement(bool justMove, float delay)
    {
        isMovementDisabled++;
        yield return new WaitForSeconds(delay);
        if (isMovementDisabled == 1)
        {
            if (life > 0)
            {
                movement.enabled = true;
                attackColdown = false;
                if (justMove)
                    yield return null;
                controller.enabled = true;
            }
        }
        isMovementDisabled--;
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Attack>() != null)
        {
            if (other.gameObject.GetComponent<Attack>().target == gameObject)
            {
                StartCoroutine(EnableMovement(false, 1f));
            }
        }

        if (other.gameObject.GetComponent<InteractableItem>() != null)
        {
            InteractableItem item = other.gameObject.GetComponent<InteractableItem>();
            switch (item.type)
            {
                case ObjectType.Potion:
                    potions++;
                    UpdateUIItem(manager.potions, potions);
                    break;
                case ObjectType.Knife:
                    swords += 3;
                    UpdateUIItem(manager.swords, swords);
                    break;
                case ObjectType.PowerUp:
                    UpdateUIItem(manager.powerUp, 1);
                    break;
                default:
                    break;
            }
            Destroy(other.gameObject);
        }
    }*/

    public void TakePotion()
    {
        if (life < 10 && potions > 0)
        {
            potions--;
            UpdateUIItem(manager.potions, potions);
            life += 4;
            life = life > 10 ? 10 : life;
            manager.PlayerHealthBar.SetHealth(life);
        }
    }

    public void ThrowSword()
    {
        StartCoroutine(ThrowSwordCo());
    }

    public void UsePowerUp()
    {
        int newCount = 0;
        newCount = int.Parse(manager.powerUp.text);
        if (newCount > 0)
        {
            powerUp = true;
            newCount--;
            manager.powerUp.text = newCount.ToString();
        }
    }

    public IEnumerator ThrowSwordCo()
    {
        if (swords > 0 && !attackColdown && movement.enabled)
        {
            attackColdown = true;
            movement.enabled = false;
            anim.SetBool("Running", false);
            anim.SetTrigger("Attacking");
            swords--;
            UpdateUIItem(manager.swords, swords);
            StartCoroutine(EnableMovement(true, 1.5f));
            yield return new WaitForSeconds(0.45f);
            hand.gameObject.SetActive(false);
            Quaternion swordRotation = Quaternion.Euler(90f, transform.eulerAngles.y, transform.eulerAngles.z);
            Instantiate(swordPrefab, hand.position, swordRotation);
            yield return new WaitForSeconds(0.3f);
            hand.gameObject.SetActive(true);
        }
    }

    public void ClosestEnemy()
    {
        enemyCloser = null;
        enemyDistance = 550;

        foreach (var enemy in FindObjectsOfType<Enemy>())
        {
            Vector3 temporalUbication = enemy.transform.position;
            temporalDistance = (temporalUbication - transform.position).magnitude;

            if (temporalDistance < enemyDistance)
            {
                enemyDistance = temporalDistance;
                enemyCloser = enemy.gameObject;
            }
        }
    }

    public void UpdateEnemyHealthBar()
    {
        ClosestEnemy();
        //manager.EnemyHealthBar.SetHealth(enemyCloser.GetComponent<Human>().life);
        /*if (DistanceTo(enemyCloser.transform.position) <= 8 && enemyCloser.GetComponent<Human>().life > 0)
            manager.EnemyHealthBar.gameObject.SetActive(true);
        else
            manager.EnemyHealthBar.gameObject.SetActive(false);*/
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

    void Update()
    {
        //UpdateEnemyHealthBar();

        /*if (life > 0)
        {
            if (Input.GetMouseButtonDown(0) && !attackColdown && movement.enabled && !manager.inventory.activeSelf)
            {
                attackColdown = true;
                movement.enabled = false;
                StartCoroutine(EnableMovement(true, 1f));
                if (powerUp)
                Attack(enemyCloser, 6, hand);
                else
                Attack(enemyCloser, 3, hand);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                TakePotion();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                ThrowSword();
            }
        }*/
    }
}
