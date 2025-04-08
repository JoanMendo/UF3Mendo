using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObjects/States/IdleState")]


public class IdleState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.Play("Idle");
    }

    public override void ExitState(PlayerInputData playerData)
    {

    }

    public override void UpdateState(PlayerInputData playerData)
    {

        //Comprovaciones para cambiar estado
        if (playerData.lastTimeJumping < Time.time + 0.2f)
        {
            playerData.playerController.ChangeState(playerData.playerController.jumpingState);
        }
        else if (playerData.MoveInput != Vector2.zero)
        {
            
            playerData.playerController.ChangeState(playerData.playerController.runningState);
        }
    }
}
