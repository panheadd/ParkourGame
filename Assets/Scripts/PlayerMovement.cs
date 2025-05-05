using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharController;
    public Transform GroundChecker;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float groundDist = 0.1f;
    public LayerMask groundMask;
    public float maxStepHeight = 0.3f; // max height adım

    bool isGrounded;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        CharController.stepOffset = maxStepHeight;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundChecker.position, groundDist, groundMask);
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        CharController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        CharController.Move(velocity * Time.deltaTime);

        AdjustStepHeight();
    }

    void AdjustStepHeight()
    {
        if (isGrounded)
        {
            CharController.stepOffset = maxStepHeight;
        }
        else
        {
            // havada olduğu
            CharController.stepOffset = 0f;
        }
    }
}
