using UnityEngine;
using UnityEngine.InputSystem;


public class NewMonoBehaviourScript : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    public PlayerController playerController;
    private InputSystem_Actions inputActions;
    private PlayerInputData playerInputData = new PlayerInputData();

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Player.SetCallbacks(this);
    }

    void OnEnable() => inputActions.Enable();
    void OnDisable() => inputActions.Disable();

    public void OnAttack(InputAction.CallbackContext context) => playerInputData.IsAttacking = context.started;
    public void OnCrouch(InputAction.CallbackContext context) => playerInputData.IsCrouching = context.started;
    public void OnInteract(InputAction.CallbackContext context) => playerInputData.IsInteracting = context.started;
    public void OnJump(InputAction.CallbackContext context) => playerInputData.IsJumping = context.started;
    public void OnLook(InputAction.CallbackContext context) => playerInputData.LookInput = context.ReadValue<Vector2>();
    public void OnMove(InputAction.CallbackContext context) => playerInputData.MoveInput = context.ReadValue<Vector2>();
    public void OnSprint(InputAction.CallbackContext context) => playerInputData.IsSprinting = context.started;

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
    void Update()
    {
        if (playerController != null)
        {
            playerController.UpdatePlayerInput(playerInputData);
        }
    }
}