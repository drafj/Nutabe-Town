using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : MonoBehaviour
{
    public int life;
    public Animator anim;
    [HideInInspector] public GameManager manager;
    private int
        battlesWon,
        battlesLost,
        gamesPlayed;

    public IEnumerator Attack(Transform hand, EnemyType type)
    {
        float t = 0f;

        switch (type)
        {
            case EnemyType.Vigilante:
                t = 0.3f;
                break;
            case EnemyType.Predicador:
                t = 0.45f;
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(t);
        anim.SetBool("IsMoving", false);
        anim.SetTrigger("Attack");
        hand.gameObject.SetActive(true);
        yield return new WaitForSeconds(t);
        hand.gameObject.SetActive(false);
    }

    public float DistanceTo(Vector3 obj)
    {
        Vector3 distance = (obj - transform.position);
        float objectDistance = distance.magnitude;
        return objectDistance;
    }
}
