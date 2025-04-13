using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "DodgingState", menuName = "ScriptableObjects/States/DodgingState")]


public class DodgingState : StatesSO
{
    public bool dodging;
    public float dodgeSpeed = 10f;
    private float dodgeDuration = 0.5f;

    public override void EnterState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isDodging", true);

        dodging = false;
    }

    public override void ExitState(PlayerInputData playerData)
    {
        playerData.characterAnimator.SetBool("isDodging", false);
        dodging = false;
        lastEndTime = Time.time;
    }

    public override void UpdateState(PlayerInputData playerData)
    {
        Vector3 moveDirection = playerData.MoveInput == Vector2.zero ? playerData.characterRigidBody.transform.forward : new Vector3(playerData.MoveInput.x, 0, playerData.MoveInput.y);
        playerData.characterRigidBody.rotation = Quaternion.Slerp(playerData.characterRigidBody.rotation, Quaternion.LookRotation(moveDirection), 0.03f);
        if (!dodging)
        {
           
            dodging = true;
            lastStartTime = Time.time;
            playerData.characterRigidBody.AddForce(moveDirection * dodgeSpeed, ForceMode.Impulse);
           

        }
        
        else if (lastStartTime + 0.3f < Time.time)
        {
            
            if (playerData.MoveInput != Vector2.zero)
            {
                playerData.playerController.ChangeState(playerData.playerController.RunningState);
            }
            else
            {
                playerData.playerController.ChangeState(playerData.playerController.IdleState);
            }
        }
         
    }
}
