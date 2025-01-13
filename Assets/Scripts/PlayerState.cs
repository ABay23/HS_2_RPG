using UnityEditor.AnimatedValues;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected string animBoolName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName )
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("I Entered " + animBoolName);
    } 

    public virtual void Update()
    {
        Debug.Log(" I updated " + animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("I Exited " + animBoolName);
    }
    
}
