using UnityEngine;
using System.Collections.Generic;

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

    private float yaw = 0;
    private float pitch = 0;

    public PlayerInputData playerInputData = new PlayerInputData();
    public GameObject cameraPivot;

    void Awake()
    {
        idleState = Instantiate(idleStateAsset);
        runningState = Instantiate(runningStateAsset);
        jumpingState = Instantiate(jumpingStateAsset);
        dodgingState = Instantiate(dodgingStateAsset);
        dyingState = Instantiate(dyingStateAsset);

        playerInputData.characterRigidBody = GetComponent<Rigidbody>();
        playerInputData.characterAnimator = GetComponent<Animator>();
        playerInputData.playerController = this;

        ChangeState(idleState);
    }

    void Update()
    {
        if (currentState != null)
        {
            CameraMovement();     // Actualizar primero rotación
            SetMoveDirection();  // Luego calcular dirección
            currentState.UpdateState(playerInputData);
        }
    }

    public bool ChangeState(StatesSO newState)
    {
        if (currentState != null)
        {
            if (Time.time > newState.cooldown + newState.lastEndTime)
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

    public void CameraMovement()
    {
        Vector2 lookInput = playerInputData.LookInput;

        yaw += lookInput.x * 60 * Time.deltaTime;
        pitch -= lookInput.y * 20 * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, 0, 15);

        // Rotar el personaje en Y y la cámara localmente en X
        transform.rotation = Quaternion.Euler(0, yaw, 0);
        cameraPivot.transform.localRotation = Quaternion.Euler(pitch, 0, 0);
    }

    public void SetMoveDirection()
    {

        Vector3 moveDirection = (cameraPivot.transform.forward * playerInputData.MoveInput.y + cameraPivot.transform.right * playerInputData.MoveInput.x);
        Debug.DrawRay(transform.position, moveDirection, Color.red, 0.5f);
        playerInputData.MoveDirection = moveDirection;
    }

    public StatesSO IdleState => idleState;
    public StatesSO RunningState => runningState;
    public StatesSO JumpingState => jumpingState;
    public StatesSO DodgingState => dodgingState;
    public StatesSO DyingState => dyingState;
}