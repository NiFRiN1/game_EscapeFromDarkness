using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _ySens = 10f;
    [SerializeField] private float _xSens = 10f;

    public Transform playerObjOrientation;
    Vector3 camOffset;
    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camOffset = new Vector3 (0,1.5f,0);
    }

    private void LateUpdate()
    {
        transform.position = playerObjOrientation.position + camOffset;
        float inputMouseX = Input.GetAxis("Mouse X") * _xSens * Time.deltaTime;
        float inputMouseY = Input.GetAxis("Mouse Y") * _ySens * Time.deltaTime;

        yRotation += inputMouseX;
        xRotation -= inputMouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // X rotation lock
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // cam rotation
        playerObjOrientation.rotation = Quaternion.Euler(0, yRotation, 0); // player rotation
    }

    public void SetSens(float value) {
        _ySens = value;
        _xSens = value;
    }
}
