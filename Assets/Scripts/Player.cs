using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move Info")]
    public float _movementSpeed = 300f;
    public float _jumpForce = 20f;

    [Header("Collission Info")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundDistance;
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private float _wallDistance;
    [SerializeField] private LayerMask _whatIsGround;

    public int _facingDirection {get; private set;} = 1;
    public bool _facingRight = true;

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
        FlipControl(_xAxis);
    }

    public bool IsGroundDetected()=> Physics2D.Raycast(_groundCheck.position, Vector2.down, _groundDistance, _whatIsGround);

    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(_groundCheck.position, new Vector3(_groundCheck.position.x, _groundCheck.position.y - _groundDistance, 0) );
        Gizmos.DrawLine(_wallCheck.position, new Vector3(_wallCheck.position.x + _wallDistance, _wallCheck.position.y));
    }

    public void Flip()
    {
        _facingDirection *= -1;
        _facingRight = !_facingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipControl(float _x)
    {
        if (_x > 0 && !_facingRight)
            Flip();
        else if (_x < 0 && _facingRight)
            Flip();
        
    }
}
