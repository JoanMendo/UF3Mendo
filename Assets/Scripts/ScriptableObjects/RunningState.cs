using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "RunningState", menuName = "ScriptableObjects/States/RunningState")]


public class RunningState : StatesSO
{
    public float walkingSpeed = 10f;
    public float runningMultiplier = 2f;
    private bool changedState = false;
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isMoving", true);
        lastStartTime = Time.time;
        changedState = false;
    }

    public override void ExitState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isMoving", false);

        playerData.characterAnimator.SetBool("isRunning", false);
        lastEndTime = Time.time;

    }

    public override void UpdateState(PlayerInputData playerData)
    {
        //Comprovaciones para cambiar estado
        if (Time.time <  playerData.lastTimeDodging + 0.15f && playerData.lastTimeDodging != 0)
        {
            changedState = playerData.playerController.ChangeState(playerData.playerController.DodgingState);
        }
        else if (Time.time < 0.15f + playerData.lastTimeJumping && playerData.lastTimeJumping != 0f)
        {
            changedState = playerData.playerController.ChangeState(playerData.playerController.JumpingState);
        }

        else if (playerData.MoveInput == Vector2.zero)
        {
            changedState = playerData.playerController.ChangeState(playerData.playerController.IdleState);
        }
        if (changedState == false)
        {
            Vector3 moveDirection = new Vector3(playerData.MoveInput.x, 0f, playerData.MoveInput.y);
            if (playerData.isSprinting)
            {
                playerData.characterAnimator.SetBool("isRunning", true);
                playerData.characterRigidBody.MovePosition(playerData.characterRigidBody.position + moveDirection * walkingSpeed * runningMultiplier * Time.deltaTime);
            }
            else
            {
                playerData.characterAnimator.SetBool("isRunning", false);
                playerData.characterRigidBody.MovePosition(playerData.characterRigidBody.position + moveDirection * walkingSpeed  * Time.deltaTime);
            }
            
            playerData.characterRigidBody.rotation = Quaternion.Slerp(playerData.characterRigidBody.rotation, Quaternion.LookRotation(moveDirection), 0.03f);
        }
    }
}
