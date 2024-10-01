using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB; //variable name fix : myBody 

    public float moveSpeed;
    public float jumpForce;

    public Transform groundPoint;
    private bool isPlayerOnGround;
    public LayerMask groundIdentifier;
    public Animator anim; //Fix like

    // Start is called before the first frame update
    void Start()
    {
        InitializePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleJumping();
        UpdateAnimation();
    }


    // Handles the horizontal movement of the player
    private void HandleMovement()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);
        FlipPlayerBasedOnDirection();
    }

    // Flips the player sprite based on the movement direction
    private void FlipPlayerBasedOnDirection()
    {
        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    // Checks and handles player jump logic
    private void HandleJumping()
    {
        isPlayerOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, groundIdentifier);
        
        if (Input.GetButtonDown("Jump") && isPlayerOnGround)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }
    }

    // Updates the animator parameters based on player state
    private void UpdateAnimation()
    {
        anim.SetBool("isPlayerOnGround", isPlayerOnGround);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }

        private void InitializePlayer()
    {
    }

}
