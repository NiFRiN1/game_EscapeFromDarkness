using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FP_Controller : MonoBehaviour
{
    public Transform cam;
    private Rigidbody rb;
    private CapsuleCollider capsule;
    Quaternion cameraRot;
    Quaternion characterRot;

    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float Xsensitivity = 10f;
    [SerializeField] private float Ysensitivity = 10f;

    private float MinX = -90f;
    private float MaxX = 90f;

    float xAxisMovement;
    float zAxisMovement;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        cameraRot = cam.transform.localRotation;
        characterRot = this.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        bool grounded = IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.AddForce(Vector3.up * _jumpForce,ForceMode.Impulse);
        }

        float yRot = Input.GetAxis("Mouse X") * Ysensitivity;
        float xRot = Input.GetAxis("Mouse Y") * Xsensitivity;

        cameraRot *= Quaternion.Euler(-xRot, 0, 0);
        characterRot *= Quaternion.Euler(0, yRot, 0);

        cameraRot = ClampRotationAroundXAxis(cameraRot);

        this.transform.localRotation = characterRot;
        cam.transform.localRotation = cameraRot;

    }

    void FixedUpdate()
    {
        xAxisMovement = Input.GetAxis("Horizontal") * _moveSpeed;
        zAxisMovement = Input.GetAxis("Vertical") * _moveSpeed;
        rb.position = cam.transform.forward * zAxisMovement + cam.transform.right * xAxisMovement; //new Vector3(x * speed, 0, z * speed);
    }

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, MinX, MaxX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    bool IsGrounded()
    {
        RaycastHit hitInfo;
        if (Physics.SphereCast(transform.position, capsule.radius, Vector3.down, out hitInfo,
                (capsule.height / 2f) - capsule.radius + 0.1f))
        {
            return true;
        }
        return false;
    }
}
