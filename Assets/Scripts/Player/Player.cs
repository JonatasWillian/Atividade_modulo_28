using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    public Animator animator;

    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravit = -9.8f;
    public float jumpSpeed = 15f;

    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 1.5f;

    private float vSpeed = 0;

    [Header("Flash")]
    public List<FlashColor> flashColors;

    #region LIFE
    public void Damage(float damage)
    {
        flashColors.ForEach(i => i.Flash());
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
    #endregion

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
            }
        }

        var isWalking = inputAxisVertical != 0;

        if (isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        vSpeed -= gravit * Time.deltaTime;
        speedVector.y = vSpeed;

        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }

    /*public Rigidbody myRigidbody;

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
    }*/
}
