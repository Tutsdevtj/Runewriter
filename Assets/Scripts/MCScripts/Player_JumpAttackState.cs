using UnityEngine;

public class Player_JumpAttackState : Player_AiredState
{

    private float lastTimeAttacked;
    public bool touchedGround;

    public Player_JumpAttackState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
       

        player.SetVelocity(player.jumpAttackVelocity.x * player.facingDir, player.jumpAttackVelocity.y);
    }

    public override void Update()
    {
        base.Update();

     if (triggerCalled)
        {
            stateMachine.ChangeState(player.fallState);
        }
        
        if (player.groundDetected)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

}