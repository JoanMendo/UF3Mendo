using UnityEngine;

public class PlayerInputData 
{

    public CharacterController characterController;

    public Animator characterAnimator;

    public PlayerController playerController;
    public Vector2 MoveInput { get; set; }
    public Vector2 LookInput { get; set; }
    public double lastTimeSprinting { get; set; }
    public double lastTimeDodging { get; set; }
    public double lastTimeAttacking { get; set; }
    public double lastTimeInteracting { get; set; }
    public double lastTimeJumping { get; set; }
}
