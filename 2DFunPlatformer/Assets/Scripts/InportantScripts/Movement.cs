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
        GameEvents.instance.DashCountChanged(amountOfDashes);
        Time.timeScale = 1;
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

        
        //Glide 


        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && CheckGround())
        {
            Debug.Log("Jumping");
            rb.velocity = Vector2.up * jumpForce;
        }

        //Add manual gravity
        AddGravity();
    }

    private void FixedUpdate()
    {
        //Movement
        //float x = Input.GetAxisRaw("Horizontal");
        //X = x;
        //rb.velocity = new Vector2(x * speed, rb.velocity.y);

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

    //The CheckGround method is only called if the player presses the spacebar
    private bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 1f, LayerMask.GetMask("Ground"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Running");
        //Collides with dash wall
        if(collision.gameObject.layer == 8)
        {
            Debug.Log(X);
            //rb.velocity = new Vector2(1, rb.velocity.y);
            //amountOfDashes++;
            //GameEvents.instance.DashCountChanged(amountOfDashes);
        }
    }

    private void AddGravity()
    {
        rb.velocity = Vector2.down * 1f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            //Player is colliding with a wall
            Debug.Log("Colliding with a wall");
            rb.gravityScale = 0.1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            rb.gravityScale = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            amountOfDashes++;
            GameEvents.instance.DashCountChanged(amountOfDashes);
        }
    }

}
