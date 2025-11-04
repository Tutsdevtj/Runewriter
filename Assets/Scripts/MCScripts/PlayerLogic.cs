using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private Transform GroundCheck;
    
    [SerializeField] private float GroundDist;

    [SerializeField] private LayerMask GroundLayer;

    [SerializeField] private int totalJump = 2;

    private bool isGroundCheck;

    private int jumpLess;

    private bool canJump;

    [SerializeField] private Animator anim;
    private float inputDirection;
    private Rigidbody2D rb2d;

    [SerializeField] private Transform look;
    [SerializeField] private Transform cameraTarget;

    [SerializeField] private float cameraSpeed;
    [SerializeField] private float jumpForce = 7f;
    private bool isDirectionRight = true;
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        jumpLess = totalJump;
    }


    void Update()
    {
        GetInputMove();
        DirectionCheck();
        CanJump();
        MoveAnim();
        jumpAnim();
    }

    void FixedUpdate()
    {
        MoveLogic();
        checkArea();
        CameraMove();
    }


    void CanJump() 
    {
        if (isGroundCheck)
        {
            jumpLess = totalJump;
        }
    
        if (jumpLess <= 0)
        {
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

    void checkArea()
    {
        isGroundCheck = Physics2D.OverlapCircle(GroundCheck.position, GroundDist, GroundLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundCheck.position, GroundDist);
    }

    void DirectionCheck()
    {
        if (isDirectionRight && inputDirection < 0)
        {
            Flip();
        }
        else if (!isDirectionRight && inputDirection > 0)
        {
            Flip();
        }
    }
    
    void CameraMove()
    {
        cameraTarget.position = Vector3.MoveTowards(cameraTarget.position, look.position, cameraSpeed * Time.deltaTime);
    }

    void Flip()
    {
        isDirectionRight = !isDirectionRight;
        transform.Rotate(0f, 180f, 0f);
    }


  void GetInputMove()
    {
        inputDirection = Input.GetAxisRaw("Horizontal"); 

        if (Input.GetButtonDown("Jump")) 
        {
            Jump();
        }
    }

    void Jump()
    {
        if (canJump)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            jumpLess--;
        }
    }
    
    void jumpAnim()
    {
        anim.SetFloat("VerticalAnim", rb2d.linearVelocityY);
    }

    void MoveAnim()
    {
        anim.SetFloat("HorizontalAnim", rb2d.linearVelocityX);
        anim.SetBool("GroundCheck", isGroundCheck);
    }

    void MoveLogic()
    {
        rb2d.linearVelocity = new Vector2(inputDirection * moveSpeed, rb2d.linearVelocity.y);
    }


}
