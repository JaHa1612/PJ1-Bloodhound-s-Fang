using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{

    [Header("Move info")]
    [SerializeField] private float moveSpeed;

    [Header("Player detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDetection;
    

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();


        if (!isGrounded || isWallDetected)
            Flip();

        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    protected override void CollisionCheck()
    {
        base.CollisionCheck();


    }
}
