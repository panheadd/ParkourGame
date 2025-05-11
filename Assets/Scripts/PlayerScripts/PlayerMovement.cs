using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace player{

public class PlayerMovement : MonoBehaviour
{
    public CharacterController CharController;
    public Transform GroundChecker;
    public float speed = 4f;
    public float sprintSpeed = 8f;
    public float crouchSpeed = 2f;
    public float crouchHeight = 1f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    public float groundDist = 0.1f;
    public LayerMask groundMask;
    public float maxStepHeight = 0.3f; // max height adım
    private float currentSpeed;
    private bool isCrouching = false;
    private float originalHeight;
    private Vector3 originalCenter;
    private Vector3 originalGroundCheckerLocalPos;
    public LayerMask obstacleMask;

    private PlayerAbilities abilities;


    public bool isGrounded;
    public Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {   
        abilities = GetComponent<PlayerAbilities>();

        CharController.stepOffset = maxStepHeight;
        originalHeight = CharController.height;
        originalCenter = CharController.center;
        originalGroundCheckerLocalPos = GroundChecker.localPosition;

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

        currentSpeed = speed;

       if (Input.GetKeyDown(KeyCode.LeftControl))
        {
        ToggleCrouch();
        }




    if (!isCrouching && Input.GetKey(KeyCode.LeftShift))
    {
        currentSpeed = sprintSpeed;
    }
    else if (isCrouching)
    {
        currentSpeed = crouchSpeed;
    }


        Vector3 move = transform.right * x + transform.forward * z;
        CharController.Move(move * currentSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump"))
        {
            if(isGrounded){
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                abilities.candoubleJump = true;
            }
            
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
    void ToggleCrouch()
{
    if (isCrouching)
    {
        float headClearance = originalHeight - crouchHeight;
        Vector3 checkStart = transform.position + Vector3.up * (crouchHeight / 2f);
        float checkRadius = CharController.radius - 0.05f;

        bool canStand = !Physics.CheckCapsule(
            checkStart,
            checkStart + Vector3.up * headClearance,
            checkRadius,
            obstacleMask
        );

        if (!canStand)
            return;
    }

    isCrouching = !isCrouching;
    StopAllCoroutines();
    StartCoroutine(SmoothCrouchChange(isCrouching));
}
IEnumerator SmoothCrouchChange(bool toCrouch)
{
    float targetHeight = toCrouch ? crouchHeight : originalHeight;
    Vector3 targetCenter = toCrouch 
        ? new Vector3(originalCenter.x, crouchHeight / 2f, originalCenter.z)
        : originalCenter;

    Vector3 targetGroundChecker = toCrouch
        ? new Vector3(
            originalGroundCheckerLocalPos.x,
            originalGroundCheckerLocalPos.y - (originalHeight - crouchHeight) / 2f,
            originalGroundCheckerLocalPos.z)
        : originalGroundCheckerLocalPos;

    float duration = 0.1f;
    float elapsed = 0f;

    float startHeight = CharController.height;
    Vector3 startCenter = CharController.center;
    Vector3 startGroundChecker = GroundChecker.localPosition;

    while (elapsed < duration)
    {
        float t = elapsed / duration;
        CharController.height = Mathf.Lerp(startHeight, targetHeight, t);
        CharController.center = Vector3.Lerp(startCenter, targetCenter, t);
        GroundChecker.localPosition = Vector3.Lerp(startGroundChecker, targetGroundChecker, t);
        elapsed += Time.deltaTime;
        yield return null;
    }

    CharController.height = targetHeight;
    CharController.center = targetCenter;
    GroundChecker.localPosition = targetGroundChecker;

    if (!toCrouch && isGrounded)
    {
        velocity.y = -2f;
        CharController.Move(Vector3.down * 0.05f);
    }
}
}
}
