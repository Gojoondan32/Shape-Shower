using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColour;
    [SerializeField] private SpriteRenderer rend;

    public int gCost;
    public int hCost;
    private int fCost;

    public int FCost { get { return gCost + hCost; } }

    public void Init(bool isOffset)
    {
        baseColor.a = 1;
        offsetColour.a = 1;
        //One line if statement
        rend.color = isOffset ? offsetColour : baseColor;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
