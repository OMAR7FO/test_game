using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallGrabState : PlayerTouchingWallState
{
    private Vector2 holdPosition;
    public PlayerWallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData,string animationName) : base(player, stateMachine, playerData, animationName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        holdPosition = player.transform.position;
        HoldPosition();
    }

    public override void LogicalUpdate()
    {
        base.LogicalUpdate();
        if (!isExitingState)
        {
            HoldPosition();
            if (yInput > 0)
            {
                stateMachine.ChangeState(player.PlayerWallClimbState);
            }
            else if (yInput < 0 || !grapInput) 
            {
                stateMachine.ChangeState(player.PlayerWallSlideState);
            }

        }
    }
    private void HoldPosition()
    {
        player.SetVelocityX(0);
        // try to remove this when you add the cinemachine camera and see what happen 
        // the cinemachine camera follow the velocity of the player because that we make the y velocity is 0
        player.SetVelocityY(0);
        player.transform.position = holdPosition;
    }
}
