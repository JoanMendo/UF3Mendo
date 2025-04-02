using UnityEngine;

public class PlayerInputData 
{
    public Vector2 MoveInput { get; set; }
    public Vector2 LookInput { get; set; }
    public bool IsSprinting { get; set; }
    public bool IsCrouching { get; set; }
    public bool IsAttacking { get; set; }
    public bool IsInteracting { get; set; }
    public bool IsJumping { get; set; }
}
