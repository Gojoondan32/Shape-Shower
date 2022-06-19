using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private float time;
    // Start is called before the first frame update
    void Start()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        LeanTween.moveY(gameObject, maxHeight, time).setOnComplete(MoveDown);
    }
    private void MoveDown()
    {
        LeanTween.moveY(gameObject, minHeight, time).setOnComplete(MoveUp);
    }
}
