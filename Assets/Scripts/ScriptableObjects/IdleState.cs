using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "IdleState", menuName = "ScriptableObjects/States/IdleState")]


public class IdleState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isIdle", true);
    }

    public override void ExitState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isIdle", false);
    }

    public override void UpdateState(PlayerInputData playerData)
    {

        //Comprovaciones para cambiar estado
        if (playerData.MoveInput != Vector2.zero)
        {
            
            playerData.playerController.ChangeState(playerData.playerController.runningState);
        }
    }
}
