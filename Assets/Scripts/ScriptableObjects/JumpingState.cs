using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using System.Threading.Tasks;



[CreateAssetMenu(fileName = "JumpingState", menuName = "ScriptableObjects/States/JumpingState")]

public class JumpingState : StatesSO
{
    public float jumpForce = 5f;   

    public bool jumping;

    public bool grounded;

    private Vector3 direction;

    private float isSprinting;

    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isJumping", true);
        playerData.characterAnimator.SetBool("isGrounded", false);
        jumping = false;
        direction = new Vector3(playerData.MoveInput.x, 0f, playerData.MoveInput.y);
        isSprinting = playerData.isSprinting ? 1.3f : 1f;
        playerData.characterRigidBody.AddForce(direction * 3f , ForceMode.Impulse); // Add a small forward force to the jump so that it doesnt suddently move



    }

    public override void ExitState(PlayerInputData playerData)
    {
        jumping = false;
        playerData.characterAnimator.SetBool("isJumping", false);
        lastEndTime = Time.time;
    }

    public override void UpdateState(PlayerInputData playerData)
    {
        if (!jumping)
        {
            if (playerData.characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump_Start"))
            {
                jumping = true;
                direction = new Vector3(direction.x, Vector3.up.y, direction.y);
                lastStartTime = Time.time;
                playerData.characterRigidBody.AddForce(direction * jumpForce *  isSprinting, ForceMode.Impulse);
                playerData.characterRigidBody.linearDamping *= 0.3f; // Reduce the linear damping to make the jump more floaty

            }
        }
        else if (Physics.Raycast(playerData.characterRigidBody.position, Vector3.down, 0.2f) && playerData.characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump_Idle"))
        {

            playerData.characterAnimator.SetBool("isGrounded", true);
            playerData.playerController.ChangeState(playerData.playerController.IdleState);
            playerData.characterRigidBody.linearDamping /= 0.3f; // Reset the linear damping to its original value
        }




        
            
    }

}
