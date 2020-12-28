using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Midle, Right }

public class WheelController : MonoBehaviour
{
    // -1.6 -0.1 1.4
    [SerializeField] private float rotateSpeed = 0;
    [SerializeField] private float moveForwardSpeed = 0;
    [SerializeField] private float moveDownSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private GameObject gameController;

    private Rigidbody rb;
    private Side playerSide;

    private float codeTimer;
    private float pointToMove;

    private bool isChangingSide = false;

    private void Start()
    {
        codeTimer   = 0.25f;

        rb          = GetComponent<Rigidbody>();
        playerSide  = Side.Right;
    }
    private void MoveTo()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, pointToMove, 0.2f), 
            transform.position.y, 
            transform.position.z);
    }
    private void FixedUpdate()
    {
        if (isChangingSide)
        {
            codeTimer -= Time.deltaTime;
            MoveTo();

            if (codeTimer < 0)
            {
                isChangingSide = false;
                codeTimer = 0.25f;
                transform.position = new Vector3(pointToMove, transform.position.y, transform.position.z);
            }
        }

        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z + moveForwardSpeed);
        }

        transform.Rotate(Vector3.forward * rotateSpeed);
    }

    public void MoveRight()
    {
        if (playerSide == Side.Left)
        {
            pointToMove = -0.1f;
            playerSide = Side.Midle;
        }
        else if (playerSide == Side.Midle)
        {
            pointToMove = 1.4f;
            playerSide = Side.Right;
        }
        else if (playerSide == Side.Right)
        {
            //...
        }
        isChangingSide = true;
    }

    public void MoveLeft()
    {
        if (playerSide == Side.Midle)
        {
            pointToMove = -1.6f;
            playerSide = Side.Left;
        }
        else if (playerSide == Side.Right)
        {
            pointToMove = -0.1f;
            playerSide = Side.Midle;
        }
        else if (playerSide == Side.Left)
        {
            // ...
        }
        isChangingSide = true;
    }

    public void MoveUp() // Jump
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + jumpForce, rb.velocity.z);
        }
    }

    public void MoveDown()
    {
        if (!IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, -moveDownSpeed, rb.velocity.z);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.8f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            gameController.GetComponent<GameController>().OnEnableLoseMenu();
        }
    }
}
