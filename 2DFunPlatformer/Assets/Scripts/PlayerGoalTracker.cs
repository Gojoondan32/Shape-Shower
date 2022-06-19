using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoalTracker : MonoBehaviour
{
    private int currentGoals;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Goal"))
        {
            if(collision.GetComponent<Goal>().GoalPriority == currentGoals)
            {
                currentGoals++;
                GameEvents.instance.CheckWinCondtion(currentGoals);
                Debug.Log("Hit the correct goals");
            }
        }
    }
}
