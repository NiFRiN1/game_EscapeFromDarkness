using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Transform playerOrientation;
    public Transform playerCamera;
    public MenuController menu;
    [SerializeField] private float currentMoveSpeed;

    private float xAxisInput;
    private float zAxisInput;

    private Vector3 moveDirection;
    private Rigidbody rb;
    [SerializeField] private CapsuleCollider capsule;

    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;
    private bool readyToJump = true;

    private Transform platform; // platform link
    private Vector3 platformPosition;
    private Quaternion platformRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayerInput();
        SpeedControl();
        

        if (IsGrounded())
        {
            rb.drag = 4;
        }
        else
        {
            rb.drag = 0;
        }

        InvokePauseMenu();

    }
    private void FixedUpdate()
    {
        if (platform != null)
        {
            // Platform movement to player rb
            Vector3 platformMovement = platform.position - platformPosition;
            rb.position += platformMovement;

            // Platform rotation to player rb
            Quaternion platformRotationDelta = platform.rotation * Quaternion.Inverse(platformRotation);
            rb.MoveRotation(platformRotationDelta * rb.rotation);
            // Updating platform position & rotation
            platformPosition = platform.position;
            platformRotation = platform.rotation;
        }
        MovePlayer();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("HopedOn");
            platform = collision.transform; // saving platform.transform component
            platformPosition = platform.position;
            platformRotation = platform.rotation;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("HopedOff");
            platform = null;
        }
    }
    

    private void PlayerInput()
    {
        xAxisInput = Input.GetAxisRaw("Horizontal");
        zAxisInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && readyToJump && IsGrounded())
        {
            Jump();
            readyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }
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
                (capsule.height / 2f) - capsule.radius + 0.2f))
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
    public bool InvokePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.Pause();
        }
        return true;
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce((transform.up + moveDirection) * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }
}
