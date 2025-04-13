using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObjects/States/IdleState")]


public class IdleState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isIdle", true);
        lastStartTime = Time.time;
    }

    public override void ExitState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isIdle", false);
        playerData.characterAnimator.SetBool("isAFK", false);
        playerData.characterAnimator.SetBool("isEmoting", false);
        lastEndTime = Time.time;
    }

    public override void UpdateState(PlayerInputData playerData)
    {

        if (Time.time < 0.15f + playerData.lastTimeDodging && playerData.lastTimeDodging != 0f)
        {
            playerData.playerController.ChangeState(playerData.playerController.DodgingState);
        }
        else if (Time.time < 0.15f + playerData.lastTimeJumping && playerData.lastTimeJumping != 0f)
        {

            playerData.playerController.ChangeState(playerData.playerController.JumpingState);
        }
        else if (playerData.MoveInput != Vector2.zero)
        {
            
            playerData.playerController.ChangeState(playerData.playerController.RunningState);
        }
        else if (playerData.isEmoting)
        {
            playerData.characterAnimator.SetBool("isEmoting", true);
        }
        else if(lastStartTime + 5 < Time.time )
        {
            playerData.characterAnimator.SetBool("isAFK", true);
        }
       

    }
}
