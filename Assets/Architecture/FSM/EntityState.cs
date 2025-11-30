using UnityEngine;

public abstract class EntityState
{
    protected Animator anim;
    protected Player player;
    protected StateMachine stateMachine;
    protected string animBoolName;

    protected Rigidbody2D rb;   
    protected PlayerInputSet input;

    protected float stateTimer;

    protected bool triggerCalled;

    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.animBoolName = stateName;

        anim = player.anim;
        rb = player.rb;
        input = player.input;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        anim.SetFloat("yVelocity", rb.linearVelocity.y);

        if(input.Player.Dash.WasPressedThisFrame() && player.canDash && CanDash())
        {
            stateMachine.ChangeState(player.dashState);
            player.canDash = false;
        }
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);

    }

    public void CallAnimationTrigger()
    {
        triggerCalled = true;
    }

    private bool CanDash()
    {
        if(player.wallDetected) return false;
        if(stateMachine.currentState == player.dashState) return false;

        return true;
    }   
}
