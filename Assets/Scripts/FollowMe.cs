using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SearchService;

public class FollowMe : MonoBehaviour
{
    public Friend myFriend;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            myFriend.runAway = true;
        }
    }
}
