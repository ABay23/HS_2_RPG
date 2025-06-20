using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player._rb.linearVelocity = new Vector2(player._rb.linearVelocityX, player._jumpForce);
        
    }


    public override void Update()
    {
        base.Update();

        if (player._rb.linearVelocityY < 0)
            {
                stateMachine.ChangeState(player.airState);
            }
    }

    public override void Exit()
    {
        base.Exit();
        
    }
}
