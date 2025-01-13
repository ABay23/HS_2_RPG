using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine stateMachine {get; private set;}

    public PlayerIdleState idleState {get; private set;}

    public PlayerMoveState moveState {get; private set;}

    private void Awake() 
    {
        stateMachine = new PlayerStateMachine();
    }
}
