using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected float _stateTimer;
    protected bool _animationTriggered;

    protected float _xInput;
    protected string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName )
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player._anim.SetBool(animBoolName, true);
        _animationTriggered = false;
    } 

    public virtual void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        player._anim.SetFloat("YVelocity", player._rb.linearVelocityY);
        
        _stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        player._anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationTriggerChecked()
    {
        _animationTriggered = true;
    }
    
}
