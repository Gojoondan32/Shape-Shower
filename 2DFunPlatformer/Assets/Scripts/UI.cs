using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public GameObject deathScreen;
    private float currentTime;
    public TextMeshProUGUI timeText;
    public Text deathTime;
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.instance.playerDied += ShowDeathScreen;
        deathScreen.SetActive(false);
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
        deathTime.text = "Final Time: " + Mathf.RoundToInt(currentTime).ToString();
    }

    public void RestartButton()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }


    #region Time
    private void UpdateTime()
    {
        currentTime += Time.deltaTime;
        int tempTime = Mathf.RoundToInt(currentTime);
        timeText.text = "Time: " + tempTime.ToString();
    }
    #endregion
}
