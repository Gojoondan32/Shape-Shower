using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    Transform parent;

    [Header("Dash Variables")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float dashSpeed = 10f;
    [SerializeField] private float dashDistance = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private int amountOfDashes = 2;
    [SerializeField] private float currentDashDistance;

    private float X;

    private bool canDash;
    Vector3 dashDirection;
    //Vector3 direction; //The direction to the mouse position
    // Start is called before the first frame update
    void Start()
    {
        //GameEvents.instance.DashCountChanged(amountOfDashes);
    }

    // Update is called once per frame
    void Update()
    {
        
        //Tell the player to dash
        if (Input.GetKeyDown(KeyCode.Mouse0) && amountOfDashes > 0)
        {
            amountOfDashes--;
            GameEvents.instance.DashCountChanged(amountOfDashes);
            canDash = true;
            dashDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.transform.position;
            dashDirection.Normalize();
            currentDashDistance = 0;
        }

        //Add manual gravity
        AddGravity();
    }

    private void FixedUpdate()
    {

        Vector3 move = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rb.transform.position;
        rb.velocity = move * speed;
        //Clamp a vector magnitude
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10);
        Debug.Log("Moving");
        //Rotation
        Vector3 rotationDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation = Mathf.Atan2(rotationDirection.y, rotationDirection.x) * Mathf.Rad2Deg - 180f;
        transform.eulerAngles = Vector3.forward * rotation;

        //Dash
        if (canDash && currentDashDistance < dashDistance)//Acount for the distance from the camera
        {
            currentDashDistance += 1;
            rb.velocity = dashDirection * dashSpeed;
            rb.velocity = dashSpeed * (rb.velocity.normalized);
            Debug.Log(currentDashDistance);

        }
        else if (canDash && currentDashDistance >= dashDistance)
        {
            currentDashDistance = 0;
            rb.velocity *= 0;
            canDash = false;
        }
    }


    private void AddGravity()
    {
        rb.velocity = Vector2.down * 1f;
    }



}
