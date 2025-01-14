using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }


    public override void Update()
    {
        base.Update();

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (player._rb.linearVelocityX != 0)
        {
            player.VelocityInput(player._movementSpeed * 0.8f * (_xInput * Time.fixedDeltaTime), player._rb.linearVelocityY);
        }
    }

    public override void Exit()
    {
        base.Exit();

    
    }
}
