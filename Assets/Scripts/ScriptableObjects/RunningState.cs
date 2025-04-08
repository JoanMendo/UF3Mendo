using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "RunningState", menuName = "ScriptableObjects/States/RunningState")]


public class RunningState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isMoving", true);
    }

    public override void ExitState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isMoving", false);
    }

    public override void UpdateState(PlayerInputData playerData)
    {
        //Comprovaciones para cambiar estado
        if (playerData.MoveInput == Vector2.zero)
        {
            playerData.playerController.ChangeState(playerData.playerController.idleState);
        }
    }
}
