using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _ySens = 10f;
    [SerializeField] private float _xSens = 10f;

    public Transform playerOrientation;

    private float xRotation;
    private float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float inputMouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _xSens;
        float inputMouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _ySens;

        yRotation += inputMouseX;
        xRotation -= inputMouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // X rotation lock

        transform.rotation = Quaternion.Euler(xRotation,yRotation,0); // cam rotation
        playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0); // player rotation
    }
}
