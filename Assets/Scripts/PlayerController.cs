using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private StatesSO currentState;
    public PlayerInputData playerInputData = new PlayerInputData();

    [Header("States")]
    [SerializeField] public StatesSO idleState;
    [SerializeField] public StatesSO runningState;
    [SerializeField] public StatesSO jumpingState;
    [SerializeField] public StatesSO dodgingState;
    [SerializeField] public StatesSO dyingState;


    public void Awake()
    {

        playerInputData.characterController = GetComponent<CharacterController>();
        playerInputData.characterAnimator = GetComponent<Animator>();
        playerInputData.playerController = this;
        if (currentState == null)
        {
            ChangeState(idleState);
        }
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(playerInputData);
        }
    }


    public void ChangeState(StatesSO newState)
    {
        
        if (currentState != null)
        {
            foreach (Transition transition in currentState.transitions)
            {
                if (transition.targetState == newState && transition.hasPriority)
                {
                    currentState.ExitState(playerInputData);
                    currentState = newState;
                    currentState.EnterState(playerInputData);
                }
            }
           
        }
        else
        {
            currentState = newState;
            currentState.EnterState(playerInputData);
        }

       
    }
}
