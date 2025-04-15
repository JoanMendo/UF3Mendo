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
        //Esto para todas las direcciones del movimiento
        float currentX = playerData.characterAnimator.GetFloat("inputX");
        float currentY = playerData.characterAnimator.GetFloat("inputY");
        float targetX = playerData.MoveInput.x;
        float targetY = playerData.MoveInput.y;
        float newX = Mathf.Lerp(currentX, targetX, Time.deltaTime * 5f);
        float newY = Mathf.Lerp(currentY, targetY, Time.deltaTime * 5f);
        playerData.characterAnimator.SetFloat("inputX", newX);
        playerData.characterAnimator.SetFloat("inputY", newY);

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
