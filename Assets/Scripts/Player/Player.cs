using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody myRigidbody;

    public Animator animator;

    [Header("Movement")]
    public Vector3 directionZ;
    public Vector3 directionX;

    [Header("Jump")]
    private Vector3 velocity;
    public float forceJump = 2;

    private string animationName;

    private void Awake()
    {
        animationName = "Idle";
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        bool moving = false;

        if (Input.GetKey(KeyCode.W))
        {
            moving = true;
            transform.Translate(directionZ * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moving = true;
            transform.Translate(-directionZ * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            moving = true;
            transform.Translate(directionX * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moving = true;
            transform.Translate(-directionX * Time.deltaTime);
        }

        if (moving)
        {
            if (animationName != "Walking")
            {
                Debug.Log("Changing animation to walking");
                animator.SetTrigger("Walking");
                animationName = "Walking";
            }
        }
        else
        {
            if (animationName != "Idle")
            {
                Debug.Log("Changing animation to Idle");
                animator.SetTrigger("Idle");
                animationName = "Idle";
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.velocity = Vector3.up * forceJump;
        }
    }
}
