using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddforceTest : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform target;
    public float force = 5f;
    public float speed = 5f;
    Vector3 direction;
    Vector3 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
        transform.position = currentPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set the direction initially - only used for setting direction not moving 
        rb.velocity = direction * force;
        //Set the force applied to the rigidbody to a constant value 
        rb.velocity = force * (rb.velocity.normalized);


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Get the mouse position when the player presses the mosue button
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.transform.position;
            direction.Normalize();
        }
    }
}
