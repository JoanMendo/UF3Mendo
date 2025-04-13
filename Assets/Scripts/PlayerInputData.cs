using UnityEngine;

public class PlayerInputData 
{

    public Rigidbody characterRigidBody;

    public Animator characterAnimator;

    public PlayerController playerController;
    public Vector2 MoveInput { get; set; }
    public Vector2 LookInput { get; set; }
    public bool isSprinting { get; set; }

    public bool isEmoting { get; set; }
    public double lastTimeDodging { get; set; }
    public double lastTimeAttacking { get; set; }
    public double lastTimeInteracting { get; set; }
    public double lastTimeJumping { get; set; }
}
