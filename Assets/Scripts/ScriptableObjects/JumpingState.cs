using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "JumpingState", menuName = "ScriptableObjects/States/JumpingState")]


public class JumpingState : StatesSO
{
    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.Play("Jump_Start");
    }

    public override void ExitState(PlayerInputData playerData)
    {

    }

    public override void UpdateState(PlayerInputData playerData)
    {

        //Si la animacion actual ha terminado, ejecuta otra
        if (playerData.characterAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump_End") && playerData.lastTimeJumping > Time.time + 0.5f)
        {
            playerData.characterAnimator.Play("Idle");
            playerData.playerController.ChangeState(playerData.playerController.runningState);
        }


            
    }
}
