using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public CharacterController CharController;

    private PlayerMovement playerMovement;
    //DAsh variables 
    public bool dash = false;
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    private bool isDashing = false;
    private float dashCooldown = 1f; 
    private float dashCooldownTimer = 0f;
    //

    //Doube Jump and Jump variables
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public bool doubleJump = false;
    public bool candoubleJump;
    
    //

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        
    }

    // Update is called once per frame
    void Update()
    {
        checkDash();
        checkDoubleJump();
    }





    //Dashing functions
    private void calculateDashCooldown(){
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }
    }

    private IEnumerator Dash(){
        isDashing = true;

        Vector3 dashDirection = transform.forward;

        float dashTime = 0f;
        while (dashTime < dashDuration)
        {
            CharController.Move(dashDirection * dashSpeed * Time.deltaTime);
            dashTime += Time.deltaTime;
            yield return null;
        }

        
        dashCooldownTimer = dashCooldown;

        isDashing = false;
    }

    private void checkDash(){
        calculateDashCooldown();
        if (Input.GetKeyDown(KeyCode.Q) && dashCooldownTimer <= 0f && !isDashing && dash){
            StartCoroutine(Dash());
        }
    }

    //

    // Double jump Functions

    private void checkCandoubleJump(){
        if (playerMovement.isGrounded && playerMovement.velocity.y < 0)
        {
            candoubleJump = true;
        }
    }

    private void checkDoubleJump(){
        checkCandoubleJump();
        if (Input.GetButtonDown("Jump"))
        {
            if (doubleJump && candoubleJump)
            {
                playerMovement.velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                candoubleJump = false;
            }
        }
    }
}
