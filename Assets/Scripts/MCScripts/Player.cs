using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Animator anim;
    public PlayerInputSet input { get; private set; }
    private StateMachine stateMachine;

    
    public Player_IdleState idleState { get; private set; }
    public Player_MoveState moveState { get; private set; }

    public Player_JumpState jumpState { get; private set; }
    public Player_FallState fallState { get; private set; }

    public Player_WallSlideState wallSlideState { get; private set; }

    public Player_DashState dashState { get; private set; }

    public Player_BasicAttackState basicAttackState { get; private set; }

    public Rigidbody2D rb { get; private set; }
    public float moveSpeed = 5.5f;
    
    [Header("Attack Details")]
    public Vector2[] attackVelocity;
    public float attackVelocityDuration = 0.1f; 

    public float comboResetTime = 1.0f;

    private Coroutine queuedAttackCo;

    [Header("Movement Details")]
    
    public float jumpForce = 12f;

    [Range(0f,1f)] public float inAirMoveMultiplier = 0.7f;

    public float wallSlideSlowMultiplier = 0.9f;

    private bool facingRight = true;

    public int facingDir = 1;
    public Vector2 moveInput { get; private set; }

    [Space]
    public float dashDuration = .25f;
    public float dashSpeed = 10f;   


    [Header("Collision detection")]
    [SerializeField] private float groundCheckDistance;

    [SerializeField] private float wallCheckDistance;

    [SerializeField] private LayerMask whatIsGround;
    public bool groundDetected { get; private set; }

    public bool wallDetected { get; private set; }

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();

        stateMachine = new StateMachine();
        input = new PlayerInputSet();

        idleState = new Player_IdleState(this, stateMachine, "idle");
        moveState = new Player_MoveState(this, stateMachine, "move");
        jumpState = new Player_JumpState(this, stateMachine, "jumpFall");
        fallState = new Player_FallState(this, stateMachine, "jumpFall");
        wallSlideState = new Player_WallSlideState(this, stateMachine, "wallSlide");
        dashState = new Player_DashState(this, stateMachine, "dash");
        basicAttackState = new Player_BasicAttackState(this, stateMachine, "basicAttack");
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Start()
    {
         stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        handleCollisionDetection();
        stateMachine.UpdateActiveState();
    }

    public void EnterAttackStateWithDelay()
    {
        if(queuedAttackCo != null)
            StopCoroutine(queuedAttackCo);

        queuedAttackCo = StartCoroutine(EnterAttackStateWithDelayCo());


    }

    private IEnumerator EnterAttackStateWithDelayCo()
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(basicAttackState);
    }




    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }

    private void HandleFlip(float xVelocity)
    {
        
        if(xVelocity > 0 && !facingRight) 
        {
            Flip();
        }
        else if(xVelocity < 0 && facingRight)
        {
            Flip();
        }

    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;

        facingDir = facingDir * -1;
    }

    private void handleCollisionDetection()
    {
        groundDetected = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDir, wallCheckDistance, whatIsGround);
    }


    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(0,-groundCheckDistance));
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(wallCheckDistance * facingDir,0));
    }

    public void CallAnimationTrigger()
    {
        stateMachine.currentState.CallAnimationTrigger();
    }

}
