using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private int goalPriority;
    public int GoalPriority
    {
        get
        {
            return goalPriority;
        }
    }
}
