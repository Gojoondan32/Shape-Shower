using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This script will be responsible for keeping track of the current game state
    //What will it be able to do:
    //Pause the game
    //Unpase the game

    private int goalTarget = 3;
    [SerializeField] private GameObject exit;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.playerDied += BeginDeathEvents;
        GameEvents.instance.checkWinCondition += CheckWinCondition;

        //Start the game
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BeginDeathEvents()
    {
        Time.timeScale = 0;
    }

    private void CheckWinCondition(int currentGoals)
    {
        if (currentGoals == goalTarget)
        {
            Destroy(exit);
            Debug.Log("Win");
        }
            
    }
}
