using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Side { Left, Middle, Right }

public enum PlayerBonus { Deffault, Magnet }

public class WheelController : MonoBehaviour
{
    [HideInInspector] public Side PlayerSide;
    [HideInInspector] public PlayerBonus PlayerBonus;

    [SerializeField] private float rotateSpeed = 0;
    [SerializeField] private float moveForwardSpeed = 0;
    [SerializeField] private float moveDownSpeed = 0;
    [SerializeField] private float jumpForce = 0;

    [SerializeField] private float damageRestoreTimer = 2f;

    [SerializeField] private GameController gameController;
    [SerializeField] private GameObject wheelBody;
    [SerializeField] private GameObject man;

    private float[] sidePositionX = { 2.65f, 0.25f, -2.15f }; // 0 = Right side, 1 = Middle side, 2 = Left side
    private Rigidbody rigidbody;

    private float codeTimer;
    private float pointToMove;

    private bool isChangingSide = false;
    private bool isDamageReceived = false;

    private float savedLastPosition;
    private Side savedLastPlayerSide;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        codeTimer = 1f;

        PlayerSide = Side.Right;
        pointToMove = sidePositionX[0];

        savedLastPosition = pointToMove;
        savedLastPlayerSide = PlayerSide;

        TakeDamage();
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
                codeTimer = 1f;
                transform.position = new Vector3(pointToMove, transform.position.y, transform.position.z);
            }
        }

        if (isDamageReceived)
        {
            damageRestoreTimer -= Time.deltaTime;
            //wheelBody.transform.Rotate(Mathf.Lerp(wheelBody.transform.rotation.x, -5, 0.3f), wheelBody.transform.rotation.y, wheelBody.transform.rotation.z);

            if (damageRestoreTimer < 0)
            {
                isDamageReceived = false;
                man.GetComponent<ManController>().IsRunningFaster = false;
            }
        }

        if (IsGrounded())
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, moveForwardSpeed);
        }

        wheelBody.transform.Rotate(Vector3.forward * rotateSpeed);
    }

    public void MoveRight()
    {
        if (PlayerSide == Side.Left)
        {
            pointToMove = sidePositionX[1];
            PlayerSide = Side.Middle;

            savedLastPlayerSide = Side.Left;
            savedLastPosition = sidePositionX[2];
        }
        else if (PlayerSide == Side.Middle)
        {
            pointToMove = sidePositionX[0];
            PlayerSide = Side.Right;

            savedLastPlayerSide = Side.Middle;
            savedLastPosition = sidePositionX[1];
        }
        else if (PlayerSide == Side.Right)
        {
            savedLastPlayerSide = Side.Right;
            savedLastPosition = sidePositionX[0];

            TakeDamage();
        }

        codeTimer = 1f;
        isChangingSide = true;
    }

    public void MoveLeft()
    {
        if (PlayerSide == Side.Middle)
        {
            pointToMove = sidePositionX[2];
            PlayerSide = Side.Left;

            savedLastPlayerSide = Side.Middle;
            savedLastPosition = sidePositionX[1];
        }
        else if (PlayerSide == Side.Right)
        {
            pointToMove = sidePositionX[1];
            PlayerSide = Side.Middle;

            savedLastPlayerSide = Side.Right;
            savedLastPosition = sidePositionX[0];
        }
        else if (PlayerSide == Side.Left)
        {
            savedLastPlayerSide = Side.Left;
            savedLastPosition = sidePositionX[2];

            TakeDamage();
        }

        codeTimer = 1f;
        isChangingSide = true;
    }

    public void MoveUp() // Jump
    {
        if (IsGrounded())
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpForce, rigidbody.velocity.z);
        }
    }

    public void MoveDown()
    {
        if (!IsGrounded())
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, -moveDownSpeed, rigidbody.velocity.z);
        }
    }

    public void TakeDamage()
    {
        if (!isDamageReceived)
        {
            isDamageReceived = true;
            damageRestoreTimer = 5f;

            isChangingSide = true;
            codeTimer = 1f;

            PlayerSide = savedLastPlayerSide;
            pointToMove = savedLastPosition;
            man.GetComponent<ManController>().IsRunningFaster = true;
        }
        else
        {
            gameController.OnEnableLoseMenu();
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
