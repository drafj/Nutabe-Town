using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Human
{
    public PlayerController playerController;
    public GameObject distantPoint;
    public float 
        sightRange,
        attackRange;
    public List<GameObject> patrolPoints = new List<GameObject>();
    public NavMeshAgent agent;
    public Transform hand;
    public LayerMask layer;
    public EnemyType enemyType;
    private bool bribed;
    private int patrolIndex = 0;
    private Vector3 actualPatrolPoint;
    private Vector3 playerPosition;
    private bool stop;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        manager = GameManager.instance;

        StartCoroutine(EnemyBehaviour());
    }

    public void MoveToPoint(Vector3 point)
    {
        if (agent.enabled)
        {
            anim.SetBool("IsMoving", true);
            agent.SetDestination(point);
        }
    }

    private IEnumerator EnemyBehaviour()
    {
        while (agent.enabled)
        {
            if (!stop)
            {
                playerPosition = manager.player.transform.position;
                if (GameManager.instance.coins.Count > 0 && !bribed)
                {
                    MoveToPoint(GameManager.instance.coins[0].transform.position);
                }
                else if (DistanceTo(playerPosition) <= sightRange && !bribed)
                {
                    MoveToPoint(playerPosition);
                    if (DistanceTo(playerPosition) <= attackRange)
                    {
                        if (playerController.gotMaletin == true)
                        {
                            playerController.gotMaletin = false;
                            StartCoroutine(BeingBribed());
                            MoveToPoint(distantPoint.transform.position);
                        }
                        else
                        {
                            anim.SetTrigger("Attack");
                            agent.isStopped = true;
                            Vector3 targetPlayer = new Vector3(playerPosition.x, transform.position.y, playerPosition.z);
                            transform.LookAt(targetPlayer);
                            StartCoroutine(Attack(hand, enemyType));
                            yield return new WaitForSeconds(2f);
                        }
                    }

                    else
                    {
                        MoveToPoint(playerPosition);
                        agent.isStopped = false;
                    }
                }
                else if (!bribed)
                {
                    if (patrolPoints.Count <= 0)
                        yield return null;

                    actualPatrolPoint = patrolPoints[patrolIndex].transform.position;
                    if (DistanceTo(actualPatrolPoint) > 1.25)
                    {
                        agent.isStopped = false;
                        agent.stoppingDistance = 0.5f;
                        MoveToPoint(actualPatrolPoint);
                    }
                    else
                    {
                        patrolIndex++;
                        patrolIndex = patrolIndex == patrolPoints.Count ? 0 : patrolIndex;
                    }
                }
            }
            yield return null;
        }
    }

    public void Stop()
    {
        anim.SetBool("IsMoving", false);
        stop = true;
        Invoke("StopDelay", 2);
    }

    void StopDelay()
    {
        stop = false;
    }

    IEnumerator BeingBribed()
    {
        bribed = true;
        yield return new WaitForSeconds(15f);
        bribed = false;
    }

    private void Update()
    {
        if (GameManager.instance.ocarinaPlayed && !bribed)
        {
            MoveToPoint(distantPoint.transform.position);
            StartCoroutine(BeingBribed());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FarPoint"))
        {
            anim.SetBool("IsMoving", false);
        }

        if (other.CompareTag("Trampa"))
        {
            print("en la trampa");
            anim.SetBool("IsMoving", false);
            agent.enabled = false;
        }
        /*if (other.gameObject.GetComponent<Attack>() != null)
        {
            Invoke("EnebleNormalBehaviour", 2f);
        }

        else if (other.gameObject.GetComponent<ThrowableWeapon>() != null && agent.enabled)
        {
            agent.isStopped = true;
            knocked = true;
            TakeDamage(1);
            Invoke("EnebleNormalBehaviour", 2f);
            Destroy(other.gameObject);
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 8f);
    }
}

public enum EnemyType { Vigilante, Predicador }