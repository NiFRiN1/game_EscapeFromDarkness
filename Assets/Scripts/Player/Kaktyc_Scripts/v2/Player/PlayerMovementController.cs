using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Transform playerOrientation;
    public Transform playerCamera;
    [SerializeField] private CapsuleCollider capsule;
    //public MenuController menu;

    [SerializeField] private float currentMoveSpeed;

    private float xAxisInput;
    private float zAxisInput;

    private Vector3 moveDirection;
    private Rigidbody rb;
    

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump;

    private void Start()
    {
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            readyToJump = true;
        }
        PlayerInput();
        SpeedControl();
        //InvokePauseMenu();


        if (IsGrounded())
        {
            rb.drag = 5;
        }
        else
        {
            rb.drag = 0;
        }
    }
    private void FixedUpdate()
    {
        MovePlayer();
        if (readyToJump)
        {
            Jump();
            readyToJump = false;
            //Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void PlayerInput()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        zAxisInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer()
    {
        Vector3 forward = new Vector3(playerOrientation.forward.x, 0f, playerOrientation.forward.z).normalized;
        Vector3 right = new Vector3(playerOrientation.right.x, 0f, playerOrientation.right.z).normalized;

        moveDirection = forward * zAxisInput + right * xAxisInput;

        if (IsGrounded())
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10f, ForceMode.Force);
        }
        else if (!IsGrounded())
        {
            rb.AddForce(moveDirection.normalized * currentMoveSpeed * 10f * airMultiplier, ForceMode.Force);
        }

    }

    private bool IsGrounded()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out hitInfo,
                (capsule.height / 2f) - capsule.radius + 0.1f))
        {
            return true;
        }
        return false;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > currentMoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentMoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    //public bool InvokePauseMenu()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        menu.Pause();
    //    }
    //    return true;
    //}
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce((Vector3.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }

    //private void ResetJump()
    //{
    //    readyToJump = true;
    //}
}
