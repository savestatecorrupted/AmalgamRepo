using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    //necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;

    private bool facingRight = true;

    //variables to play with
    public float speed = 2.0f;
    public float horizMovement;


    private void Start()
    {
        //define player components
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    //handles input for physics

    private void Update()
    {
        //check direction player inputted
        horizMovement = Input.GetAxisRaw("Horizontal");


    }

    //handles running physics

    private void FixedUpdate()
    {
        //move player left or right
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        myAnimator.SetFloat("Speed",horizMovement);
        
    }

}
