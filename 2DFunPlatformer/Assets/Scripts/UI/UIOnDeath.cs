using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIOnDeath : UIManager
{
    public override void Start()
    {
        Debug.Log("Starting");
        GameEvents.instance.playerDied += ShowDeathScreen;
        deathScreen.SetActive(false);
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
