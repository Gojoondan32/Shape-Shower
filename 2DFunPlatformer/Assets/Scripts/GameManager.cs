using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This script will be responsible for keeping track of the current game state
    //What will it be able to do:
        //Pause the game
        //Unpase the game

       

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.playerDied += BeginDeathEvents;

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
}
