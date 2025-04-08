using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "RunningState", menuName = "ScriptableObjects/States/RunningState")]


public class RunningState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.Play("Walking_Slow");
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
        else if (playerData.MoveInput == Vector2.zero)
        {
            playerData.playerController.ChangeState(playerData.playerController.idleState);
        }
    }
}
