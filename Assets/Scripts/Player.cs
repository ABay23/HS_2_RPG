using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float _movementSpeed = 300f;

    #region Components
    public Animator _anim {get; private set;}
    public Rigidbody2D _rb {get; private set;}
    #endregion Components
    #region states
    public PlayerStateMachine stateMachine {get; private set;}

    public PlayerIdleState idleState {get; private set;}

    public PlayerMoveState moveState {get; private set;}

    public PlayerJumpState jumpState {get; private set;}

    public PlayerAirState airState {get; private set;}
    #endregion states

    private void Awake() 
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState  = new PlayerAirState(this, stateMachine, "Jump");
    }

    private void Start() 
    {
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponentInChildren<Rigidbody2D>();

        stateMachine.Initialize(idleState);
    }

    private void Update() 
    {
        stateMachine.currentState.Update();
        
    }
    public void VelocityInput(float _xAxis, float _yAxis)
    {
        _rb.linearVelocity = new Vector2(_xAxis, _yAxis);
    }
}
