using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public Transform playerOrientation;
    [SerializeField] private CapsuleCollider capsule;

    [SerializeField] private float currentMoveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplier;

    private float xAxisInput;
    private float zAxisInput;

    private Vector3 moveDirection;
    private Rigidbody rb;

    private bool readyToJump = true;


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
            rb.drag = 5;
        } else rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MovePlayer();
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

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Platform")
    //    {
    //        transform.SetParent(other.transform);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Platform")
    //    {
    //        transform.SetParent(null);
    //    }
    //}

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3 (rb.velocity.x, 0f, rb.velocity.z);
        
        if (flatVel.magnitude > currentMoveSpeed) //recalculate speed if it's above setted value
        {
            Vector3 limitedVel = flatVel.normalized * currentMoveSpeed;
            rb.velocity = new Vector3 (limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce (transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
