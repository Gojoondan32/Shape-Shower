using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMarker : MonoBehaviour
{
    [SerializeField] private GameObject marker;
    [SerializeField] private GameObject player;
    private void Start()
    {
        GameEvents.instance.blockSpawning += MoveMarker;
    }

    private void MoveMarker(Vector3 position)
    {
        marker.transform.position = new Vector3(position.x, transform.position.y + 4, position.z);
        FindRotation();
    }

    private void FindRotation()
    {
        Vector3 direction = player.transform.position - marker.transform.position;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        marker.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
