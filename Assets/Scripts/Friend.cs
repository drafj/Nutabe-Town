using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;
using System.Data.Common;

public class Friend : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform hand;
    public Animator anim;
    public float
    sightRange,
    attackRange;
    public List<GameObject> patrolPoints = new List<GameObject>();
    public bool runAway = false;
    public bool targetSet = false;
    private int patrolIndex = 0;
    private Vector3 actualPatrolPoint;
    private Vector3 enemyPosition;
    private float
    enemyDistance,
    temporalDistance;
    private GameObject enemyCloser;

    private void Start()
    {
        anim.SetBool("IsMoving", false);
        StartCoroutine(FriendBehaviour());
    }

    IEnumerator FriendBehaviour()
    {
        while (agent.enabled)
        {
            ClosestEnemy();
            enemyPosition = enemyCloser.transform.position;
            if (DistanceTo(enemyPosition) <= sightRange && !runAway || targetSet && !runAway)
            {
                MoveToPoint(enemyPosition);
                if (DistanceTo(enemyPosition) <= attackRange && !runAway)
                {
                    targetSet = true;
                    agent.isStopped = true;
                    Vector3 targetPlayer = new Vector3(enemyPosition.x, transform.position.y, enemyPosition.z);
                    transform.LookAt(targetPlayer);
                    StartCoroutine(Attack(hand));
                    yield return new WaitForSeconds(0.7f);
                }
            }
            else if (runAway)
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
            yield return null;
        }

    }

    public IEnumerator Attack(Transform hand)
    {
        float t = 0.3f;

        yield return new WaitForSeconds(t);
        anim.SetBool("IsMoving", false);
        anim.SetBool("Attack", true);
        hand.gameObject.SetActive(true);
        yield return new WaitForSeconds(t);
        anim.SetBool("Attack", false);
        hand.gameObject.SetActive(false);
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

    public void MoveToPoint(Vector3 point)
    {
        if (agent.enabled)
        {
            anim.SetBool("Attack", false);
            anim.SetBool("IsMoving", true);
            agent.SetDestination(point);
        }
    }

    public float DistanceTo(Vector3 obj)
    {
        Vector3 distance = (obj - transform.position);
        float objectDistance = distance.magnitude;
        return objectDistance;
    }
}
