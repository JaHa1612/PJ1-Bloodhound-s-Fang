using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player_new _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(5 * -player.facingDir, player.jumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            stateMachine.ChangeState(player.airState);

       /* if (player.IsGroundDetected())                //co the bi o collisionCheck
            stateMachine.ChangeState(player.idleState);*/

    }

}
