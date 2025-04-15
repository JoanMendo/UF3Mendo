using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Current State")]

    [SerializeField] private StatesSO currentState;

    [Header("State Assets")]
    [SerializeField] private StatesSO idleStateAsset;
    [SerializeField] private StatesSO runningStateAsset;
    [SerializeField] private StatesSO jumpingStateAsset;
    [SerializeField] private StatesSO dodgingStateAsset;
    [SerializeField] private StatesSO dyingStateAsset;

    [Header("Runtime States (Instantiated)")]
    private StatesSO idleState;
    private StatesSO runningState;
    private StatesSO jumpingState;
    private StatesSO dodgingState;
    private StatesSO dyingState;



    public PlayerInputData playerInputData = new PlayerInputData();

    void Awake()
    {
        // Instanciar los estados
        idleState = Instantiate(idleStateAsset);
        runningState = Instantiate(runningStateAsset);
        jumpingState = Instantiate(jumpingStateAsset);
        dodgingState = Instantiate(dodgingStateAsset);
        dyingState = Instantiate(dyingStateAsset);

        // Setup inicial
        playerInputData.characterRigidBody = GetComponent<Rigidbody>();
        playerInputData.characterAnimator = GetComponent<Animator>();
        playerInputData.playerController = this;

        ChangeState(idleState); // O el que sea
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(playerInputData);
            Debug.Log(playerInputData.MoveInput);
        }
    }


    public bool ChangeState(StatesSO newState)
    {
        
        if (currentState != null)
        {
           
                if ( Time.time > newState.cooldown + newState.lastEndTime)
                {
                    currentState.ExitState(playerInputData);
                    currentState = newState;
                    currentState.EnterState(playerInputData);
                    return true;
                }
            return false;
        }

        else
        {
            currentState = newState;
            currentState.EnterState(playerInputData);
            return true;
        }

    }

    public StatesSO IdleState => idleState;
    public StatesSO RunningState => runningState;
    public StatesSO JumpingState => jumpingState;
    public StatesSO DodgingState => dodgingState;
    public StatesSO DyingState => dyingState;
}
