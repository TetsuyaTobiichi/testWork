using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scri : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int maxSpeed = 10;
    public float drag;
    private Rigidbody2D body;
    public bool isGrounded = true;
    public bool isControl = true;
    public Vector2 velocity;
    private float move;
   

    void Start()
    {
        PlayerPrefs.SetInt("score", 0);
        body = GetComponent<Rigidbody2D>();
        body.drag = drag;
       
        /////////
    }

    void Update()
    {
        
        if (isControl)
        {
            //float move = Input.GetAxis("Horizontal");
            body.AddForce(new Vector2(move * speed, 0f), ForceMode2D.Force);
            LimitSpeed();
        }
       
        if (Input.GetButtonDown("Jump") && isGrounded) 
        { 
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            isControl = true;
            body.drag = drag;
            }
    }

    void FixedUpdate()
    {
        velocity = body.velocity;
        if (isGrounded && velocity.y > 1f)
        {
            isGrounded = false;
            isControl = false;
            body.drag = 0f;
        }
    }

    public void OnLeftButtonDown()
    {
        move = -1f;
        Debug.Log("лево");
    }

    public void OnButtonUp()
    {
        move = 0f;
        Debug.Log("отпустил");
    }

    public void OnRightButtonDown()
    {
        move = 1f;
        Debug.Log("право");
    }

    public void onJumpButtonDown()
    {

        if (isGrounded)
        {
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void LimitSpeed()
    {
        if (body.velocity.magnitude > maxSpeed)
        {
            
            body.velocity = velocity.normalized * maxSpeed;
        }
    }

}




