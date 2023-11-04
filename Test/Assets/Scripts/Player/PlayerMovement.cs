using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator playerAnim;

    Rigidbody playerRb;

    public FloatingJoystick joystick;

    public float moveSpeed;
    public float rotateSpeed;

    private Vector3 moveVector;


    private void Awake()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * moveSpeed * Time.deltaTime;
        moveVector.z = joystick.Vertical * moveSpeed * Time.deltaTime;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, moveVector, rotateSpeed * Time.deltaTime,0);
            transform.rotation = Quaternion.LookRotation(direction);

            playerAnim.Play("player_run");
        }
        else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
             playerAnim.Play("player_idle");
        }

        playerRb.MovePosition(playerRb.position + moveVector);
    }

}
