﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [SerializeField] float enemyMoveSpeed = 2f;
    [SerializeField] int rangedEnemyCoinValue = 75;


    Rigidbody2D myRigidBody;
    CapsuleCollider2D myCapsuleCollider2D;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight())
        {
            myRigidBody.velocity = new Vector2(enemyMoveSpeed, 0);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-enemyMoveSpeed, 0);
        }

    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    // make sure to set enemy box collider slightly in the ground for this to work.
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
    }

    private void Die()
    {
        if (myCapsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Player", "Place Holder For Player Weapon Mask"))) // add mask for player weapons later
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(rangedEnemyCoinValue);
        }
    }
}
