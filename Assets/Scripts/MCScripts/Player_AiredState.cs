using UnityEngine;

public class Player_AiredState : PlayerState
{
    public Player_AiredState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }


    public override void Update()
    {
        base.Update();

        if (player.moveInput.x != 0f)
             player.SetVelocity(player.moveInput.x * (player.moveSpeed * player.inAirMoveMultiplier), rb.linearVelocity.y);

        if (input.Player.Jump.WasPressedThisFrame() && player.canDoubleJump)
    {
        player.canDoubleJump = false;
        
        
        stateMachine.ChangeState(player.doubleJumpState);
    
    }


        if (input.Player.Attack.WasPressedThisFrame() && player.canJumpAttack) 
           {
            player.canJumpAttack = false;
            stateMachine.ChangeState(player.jumpAttackState);
            }
       
    }
}
