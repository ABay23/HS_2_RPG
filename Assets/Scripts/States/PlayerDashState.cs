using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _stateTimer = player._dashDuration;
    }

    public override void Exit()
    {
        base.Exit();
        player.VelocityInput(0, player._rb.linearVelocityY);
    }

    public override void Update()
    {
        base.Update();

        player.VelocityInput(player._dashSpeed * player._facingDirection * Time.fixedDeltaTime, 0);

        if (_stateTimer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}
