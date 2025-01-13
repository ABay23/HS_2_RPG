using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // Add code for entering the idle state
    }

    public override void Exit()
    {
        base.Exit();
        // Add code for exiting the idle state
    }

    public override void Update()
    {
        base.Update();

        if (_xInput != 0){
            stateMachine.ChangeState(player.moveState);
        }
    }

    
}
