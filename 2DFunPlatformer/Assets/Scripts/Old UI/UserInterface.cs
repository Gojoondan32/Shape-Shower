using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI dashes;

    private void Start()
    {
        GameEvents.instance.dashCountChanged += UpdateDashes;
    }

    private void UpdateDashes(int count)
    {
        dashes.text = "Dashes: " + count.ToString();
    }
}
