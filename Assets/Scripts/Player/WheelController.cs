using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Side { Left, Middle, Right }

public enum PlayerBonus { Deffault, Magnet }

public class WheelController : MonoBehaviour
{
    [HideInInspector] public Side PlayerSide; // -1.6 -0.1 1.4
    [HideInInspector] public PlayerBonus PlayerBonus;

    [SerializeField] private float rotateSpeed = 0;
    [SerializeField] private float moveForwardSpeed = 0;
    [SerializeField] private float moveDownSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject wheelBody;

    private Rigidbody rb;

    private float codeTimer;
    private float pointToMove;

    private bool isChangingSide = false;

    private void Start()
    {
        codeTimer   = 0.25f;

        rb          = GetComponent<Rigidbody>();
        PlayerSide  = Side.Right;
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
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, moveForwardSpeed);
        }

        wheelBody.transform.Rotate(Vector3.forward * rotateSpeed);
    }

    public void MoveRight()
    {
        if (PlayerSide == Side.Left)
        {
            pointToMove = -0.1f;
            PlayerSide = Side.Middle;
        }
        else if (PlayerSide == Side.Middle)
        {
            pointToMove = 1.4f;
            PlayerSide = Side.Right;
        }
        else if (PlayerSide == Side.Right)
        {
            //...
        }
        isChangingSide = true;
    }

    public void MoveLeft()
    {
        if (PlayerSide == Side.Middle)
        {
            pointToMove = -1.6f;
            PlayerSide = Side.Left;
        }
        else if (PlayerSide == Side.Right)
        {
            pointToMove = -0.1f;
            PlayerSide = Side.Middle;
        }
        else if (PlayerSide == Side.Left)
        {
            // ...
        }
        isChangingSide = true;
    }

    public void MoveUp() // Jump
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
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

    private void MoveTo()
    {
        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, pointToMove, 0.2f),
            transform.position.y,
            transform.position.z);
    }
}
