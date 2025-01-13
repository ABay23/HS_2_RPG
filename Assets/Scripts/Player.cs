using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator _anim {get; private set;}
    #endregion Components
    #region states
    public PlayerStateMachine stateMachine {get; private set;}

    public PlayerIdleState idleState {get; private set;}

    public PlayerMoveState moveState {get; private set;}
    #endregion states

    private void Awake() 
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start() 
    {
        _anim = GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
    }

    private void Update() 
    {
        stateMachine.currentState.Update();
        
    }
}
