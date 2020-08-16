using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Public Variables")]
    public float jumpforce;
    public bool grounded;
    private Rigidbody2D rb;

    [Header("Private Variables")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float circleRad;
    [SerializeField] private LayerMask whatIsGround;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, circleRad, whatIsGround);
        //use space and/or w to jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
    }

     private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, circleRad);
    }
    
}
