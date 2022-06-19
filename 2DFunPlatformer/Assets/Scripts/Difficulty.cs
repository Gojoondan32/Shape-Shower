using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DansLibrary;

public class Difficulty
{
    private int difficultyLevel = 1;
    public int DifficultyLevel { get { return difficultyLevel; } }

    public Difficulty(GlobalTimer timer)
    {
        //timer.timerCompleted += IncreaseDifficlulty;
    }
    private void IncreaseDifficlulty()
    {
        difficultyLevel++;
        //Restart the timer 
    }
}
