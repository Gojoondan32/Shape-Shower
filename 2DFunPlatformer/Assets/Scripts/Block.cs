using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Properties")]
    [SerializeField] private float scalarValue;
    public float ScalarValue { get { return scalarValue; } }
    [SerializeField] private int spawnLevel;
    public int SpawnLevel { get { return spawnLevel; } }


    [SerializeField] private int colourValue;
    public int ColourValue { get { return colourValue; } }

    private void Start()
    {
        colourValue = Random.Range(0, 2);
        SwitchColour();
        Destroy(gameObject, 50f);
    }
    private void Update()
    {
        rb.velocity = new Vector2(0, -1) * scalarValue;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameEvents.instance.PlayerDied();
            Time.timeScale = 0;
            //Player has lost
            //Destroy(collision.gameObject);
        }

    }

    private void SwitchColour()
    {
        SpriteRenderer rend = gameObject.GetComponent<SpriteRenderer>();
        //rend.color = colourValue == 0 ? rend.color = Color.white : rend.color = Color.black;
    }
}
