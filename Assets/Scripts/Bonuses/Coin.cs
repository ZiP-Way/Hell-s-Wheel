using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : BonusController
{
    private float moveObjSpeed;
    private Vector3 playerPos;
    private bool isPlayerFounded = false;

    private void FixedUpdate()
    {
        if (isPlayerFounded)
        {
            playerPos = player.transform.position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, moveObjSpeed);

            if (Vector3.Distance(transform.position, playerPos) < 0.1f)
            {
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ScoreUpdate();
                Destroy(gameObject);
            }
        }
    }

    public void MoveToPlayer(float moveObjSpeed)
    {
        this.moveObjSpeed = moveObjSpeed;
        isPlayerFounded = true;
    }
}
