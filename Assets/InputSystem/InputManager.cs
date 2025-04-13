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

    public void OnAttack(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeAttacking = Time.time;
    public void OnCrouch(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeDodging= Time.time;
    public void OnInteract(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeInteracting = Time.time;
    public void OnJump(InputAction.CallbackContext context) => playerController.playerInputData.lastTimeJumping = Time.time;
    public void OnLook(InputAction.CallbackContext context) => playerController.playerInputData.LookInput = context.ReadValue<Vector2>();
    public void OnMove(InputAction.CallbackContext context) => playerController.playerInputData.MoveInput = context.ReadValue<Vector2>();
    public void OnSprint(InputAction.CallbackContext context) => playerController.playerInputData.isSprinting = context.performed;

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnEmote(InputAction.CallbackContext context) => playerController.playerInputData.isEmoting = context.performed;



}