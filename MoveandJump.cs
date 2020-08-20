using UnityEngine;

public class MoveandJump : MonoBehaviour
{

    [Header("Movement Details")]
    private Rigidbody2D rb; 
    public float speed;
    public float jumpForce;
    private float moveInput;

    
    [Header("GroundCheck Details")]
    public Transform feetPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;
    

    [Header("Jump Time Details")]
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    public float threshold;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (transform.position.y < threshold)
            transform.position = new Vector2(-6.22f, -2.48f);

    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround); //am i on the ground?

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))  //If you're on the ground and hit space to jump
        {
            anim.SetTrigger("jumpSquat");
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            
        }

        //animation triggers for jumping
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
            anim.SetFloat("vertSpeed", 0);
            anim.SetBool("isGrounded", true); 
        }
        else
        {
            anim.SetBool("isJumping", true);
            anim.SetFloat("vertSpeed", 1 * Mathf.Sign(rb.velocity.y));
            anim.SetBool("isGrounded", false);
        }

        //holding jump until max jump height
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
            
        }
        //if you let go of jump early, you can't jump anymore
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //animation triggers for running
        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
            anim.SetFloat("Speed", moveInput);
        }
        //animation trigger for falling
        if (rb.velocity.y < -0.1)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
    }
}