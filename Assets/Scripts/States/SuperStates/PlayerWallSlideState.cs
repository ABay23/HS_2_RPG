using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }


    public override void Update()
    {
        base.Update();
        
        if (!player.IsWallDetected() && !player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        } else if (!player.IsWallDetected() && player.IsGroundDetected() )
        {
            stateMachine.ChangeState(player.idleState);
        } 

        if (player.IsWallDetected() && player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();

    
    }
}
