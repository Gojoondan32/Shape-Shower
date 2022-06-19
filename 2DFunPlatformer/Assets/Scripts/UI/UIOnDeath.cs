using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOnDeath : MonoBehaviour
{
    [SerializeField] private UIManager manager;
    private void Start()
    {
        Debug.Log("Starting");
        GameEvents.instance.playerDied += ShowDeathScreen;
        manager.deathScreen.SetActive(false);
    }

    private void ShowDeathScreen()
    {
        manager.deathScreen.SetActive(true);
        manager.finalTimeTxt.text = ($"Total Time: {Mathf.RoundToInt(manager.gameTime)}");
    }

    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
