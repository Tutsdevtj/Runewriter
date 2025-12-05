public class Player_DeadState : PlayerState
{
    public Player_DeadState(Player player, StateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.input.Player.Disable();
        rb.simulated = false;
    

        player.SetVelocity(0f,0f);

        player.TriggerDeathSequence();
    }

    public override void Update()
    {
        base.Update();
        
        player.SetVelocity(0f, player.rb.linearVelocity.y);
    }
}