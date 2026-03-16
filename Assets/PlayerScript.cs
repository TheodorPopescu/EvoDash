using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.XR;

public class PlayerScript : MonoBehaviour
{
    private bool isJumping;
    public Rigidbody2D rb;
    public float movespeed;
    public float jumpspeed;
    public float dashSpeed;
    public float dashDuration;
    public Animator anim;

    private bool hasDashed = false;
    private bool isDashing = false;
    private Vector2 moveDirection;
    private float lastHorizontalDirection = 1f;
    private Vector2 Checkpointpos;

    public Transform Groundcheck;
    public float groudCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    
    private bool wasIdle = false;

    public int k = 1;
    public InputActionReference move;
    public InputActionReference jump;
    public InputActionReference dash;

    private void OnEnable()
    {
        move.action.Enable();
        jump.action.Enable();
        dash.action.Enable();

        jump.action.started += Jump;
        dash.action.started += Dash;
    }
    private void Start()
    {
        Checkpointpos = transform.position;
    }

    private void OnDisable()
    {
        move.action.Disable();
        jump.action.Disable();
        dash.action.Disable();

        jump.action.started -= Jump;
        dash.action.started -= Dash;
    }

    void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();

        isGrounded = Physics2D.OverlapCircle(Groundcheck.position, groudCheckRadius, groundLayer);

        if (isGrounded)
        {
             hasDashed = false;
        }
        if (isGrounded == true && rb.linearVelocity.y <= 0.1f)
        {
            isJumping = false;
        
            k = 0;
        }

        // Store the last horizontal direction the player was moving
        if (moveDirection.x != 0)
        {
            lastHorizontalDirection = Mathf.Sign(moveDirection.x);

            if (moveDirection.x > 0)
            {
                transform.localScale = new Vector3(3, 3, 3);   // Face Right
            }
            else if (moveDirection.x < 0)
            {
                transform.localScale = new Vector3(-3, 3, 3);  // Face Left
            }
        }

       
        HandleMovement();

        if (transform.position.y <= -5)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = Checkpointpos;
    }
    public void UpdateCheckpoint(Vector2 pos)
    {
        Checkpointpos = pos;
    }
    private void FixedUpdate()
    {
        // Don't allow player control while dashing
        if (isDashing) return;

        if (k == 0)
        {
            rb.linearVelocity = new Vector2(moveDirection.x * movespeed, rb.linearVelocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isDashing) return;

        if (isGrounded)
        {
            isJumping = true;
            wasIdle = false; // We are jumping, so forget the idle state

            rb.AddForce(Vector2.up * jumpspeed, ForceMode2D.Impulse);
            anim.ResetTrigger("IdleTrigger");
            anim.SetTrigger("JumpTrigger");
            anim.SetBool("IsRunning", false);
          
           
        }
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if (isDashing || hasDashed == true) return;

        if (isGrounded == false)
        {
            StartCoroutine(PerformDash());
        }
    }

    private IEnumerator PerformDash()
    {
        anim.ResetTrigger("JumpTrigger");
        anim.SetTrigger("DashTrigger");

        k = 1;
        isDashing = true;
        hasDashed = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // use last horizontal direction
        rb.linearVelocity = new Vector2(lastHorizontalDirection * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); // Stop horizontal movement while dashing
        isDashing = false;
        k = 0;
        
    }

    private void HandleMovement()
    {
         
        if (isGrounded == true && isJumping == false)
        {
            if (moveDirection.x != 0) // Running
            {
                anim.SetBool("IsRunning", true);
                anim.ResetTrigger("IdleTrigger");
                wasIdle = false;
            }
            else // Idle
            {
                anim.SetBool("IsRunning", false);

              
                if (wasIdle == false)
                {
                    anim.SetTrigger("IdleTrigger");
                    wasIdle = true;
                }
            }
        }
        else // We are in the air
        {
            wasIdle = false;
        }
    }

}