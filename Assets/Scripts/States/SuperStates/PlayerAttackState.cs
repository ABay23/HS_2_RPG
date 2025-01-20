using NUnit.Framework;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    private int _comboCounter;
    private float _lastTimeAttacked;
    private float _comboWindow = 2f;

    public override void Enter()
    {
        base.Enter();

        if (_comboCounter > 2 || Time.time >= _lastTimeAttacked + _comboCounter)
            _comboCounter = 0;

        player._anim.SetInteger("ComboA", _comboCounter);
    }


    public override void Update()
    {
        base.Update();

        if (_animationTriggered)
            stateMachine.ChangeState(player.idleState);

        if (_stateTimer > 0)
            player._rb.linearVelocity = new Vector2(0, 0);
    }

    public override void Exit()
    {
        base.Exit();

        _comboCounter ++;
        _lastTimeAttacked = Time.time;
        Debug.Log(_lastTimeAttacked);

    
    }
}
