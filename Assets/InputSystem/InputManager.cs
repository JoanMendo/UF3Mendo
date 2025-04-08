using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public PlayerController playerController;
    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);

    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    public void OnAttack(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeAttacking = context.startTime;
    public void OnCrouch(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeDodging= context.startTime;
    public void OnInteract(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeInteracting = context.startTime;
    public void OnJump(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeJumping = context.startTime;
    public void OnLook(InputAction.CallbackContext context) => playerController.playerInputData.LookInput = context.ReadValue<Vector2>();
    public void OnMove(InputAction.CallbackContext context) => playerController.playerInputData.MoveInput = context.ReadValue<Vector2>();
    public void OnSprint(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeSprinting = context.startTime;

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

}