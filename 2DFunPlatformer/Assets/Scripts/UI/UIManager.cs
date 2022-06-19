using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] protected GameObject deathScreen;
    [SerializeField] protected TextMeshProUGUI gameTimeTxt;


    [Header("Values that change")]
    private float gameTime;
    // Start is called before the first frame update
    public virtual void Start()
    {
        gameTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime();   
    }

    private void UpdateGameTime()
    {
        gameTime += Time.deltaTime;
        //Round the current time to an integer to remove the decimals 
        gameTimeTxt.text = "Time: " + Mathf.RoundToInt(gameTime).ToString();

    }

}
