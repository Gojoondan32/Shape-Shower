using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DansLibrary;

public class MasterTimer : MonoBehaviour
{
    /*
    private float maxTime;
    public float MaxTime { private get { return maxTime; } set { maxTime = value; } }
    public void CreateNewTimer(float maxTime, bool repeating)
    {
        GlobalTimer timer = new GlobalTimer(maxTime);
        StartCoroutine(timer.ScaledTimer(timer));
        MaxTime = maxTime;

        if (repeating)
            timer.timerCompleted += TimerFinished;
    }

    private void TimerFinished(GlobalTimer timer)
    {
        timer.MaxTime = MaxTime;
        Debug.Log(timer.MaxTime.ToString());
        StartCoroutine(timer.ScaledTimer(timer));
    }
    */
}
